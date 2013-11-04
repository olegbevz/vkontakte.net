// -----------------------------------------------------------------------
// <copyright file="DownLoaderViewModel.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace VKontakteNet
{
    using System;
    using System.ComponentModel;
    using System.IO;
    using System.Net;
    using System.Windows.Forms;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class DownLoaderViewModel : ViewModelWithConnection
    {
        public DownLoaderViewModel(Connection connection):base(connection)
        {
            Id = Connection.UserId.ToString();

            OnPropertyChanged("Id");

            UpdateCommand.Execute(this);
        }

        public string Id { get; set; }

        public UserExtended User { get; set; }

        public ImageSource UserImage
        {
            get
            {
                var bytes = new WebClient().DownloadData(User.PhotoUrl);

                using (var stream = new MemoryStream(bytes))
                {
                    return BitmapFrame.Create(
                        stream, 
                        BitmapCreateOptions.None, 
                        BitmapCacheOption.None);
                }
            }
        }

        private string _status;

        public string Progress
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;

                OnPropertyChanged("Progress");
            }
        }

        private bool _isFree = true;

        public bool IsFree
        {
            get
            {
                return _isFree;
            }

            set
            {
                _isFree = value;

                this.OnPropertyChanged("IsFree");
            }
        }

        #region - Команды -

        public RelayCommand UpdateCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    int id;

                    if (int.TryParse(Id, out id))
                    {
                        var profileAdapter = new ProfileAdapter(Connection);

                        User = profileAdapter.GetProfile<UserExtended>(id);

                        this.OnPropertyChanged("User");

                        this.OnPropertyChanged("UserImage");
                    }
                });
            }
        }

        public RelayCommand LoadPhotoCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    var dialog = new FolderBrowserDialog();

                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        var adapter = new PhotoAdapter(Connection);

                        var albums = adapter.GetAlbums(User.Id);

                        foreach (var album in albums)
                        {
                            var directory = Path.Combine(dialog.SelectedPath, album.Title);

                            Directory.CreateDirectory(directory);

                            var photos = adapter.GetPhotos(User.Id, album.Id);

                            LoadThread(photos, directory);
                        }
                    }
                }, e => IsFree);
            }
        }

        public RelayCommand LoadAudioCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    var dialog = new FolderBrowserDialog();

                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        var adapter = new AudioAdapter(Connection);

                        var audios = adapter.GetUserAudio(User.Id);

                        LoadThread(audios, dialog.SelectedPath);
                    }
                }, e => IsFree);
            }
        }

        public RelayCommand LoadDocumentCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    var dialog = new FolderBrowserDialog();

                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        var adapter = new DocumentAdapter(Connection);

                        var audios = adapter.GetDocuments(User.Id);

                        LoadThread(audios, dialog.SelectedPath);
                    }
                }, e => IsFree);
            }
        }

        #endregion

        private void LoadThread(Resource[] resources, string directory)
        {
            var worker = new BackgroundWorker { WorkerReportsProgress = true };

            worker.ProgressChanged += (sender, e) => { Progress = e.UserState.ToString(); };

            worker.DoWork += this.Worker_DoWork;

            worker.RunWorkerAsync(new object[] { resources, directory });
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            IsFree = false;

            var args = e.Argument as object[];

            var resources = args[0] as Resource[];

            var directory = args[1] as string;

            if (resources != null)
            {
                Load(resources, directory, sender);
            }

            IsFree = true;
        }

        private void Load(Resource[] resources, string directory, object sender)
        {
            var progress = string.Empty;

            var webClient = new WebClient();

            for (var i = 0; i < resources.Length; i++)
            {
                var resource = resources[i];

                progress = string.Format("Загружаем : {0} ({1} из {2})", resource.FileName, i + 1, resources.Length);

                ((BackgroundWorker)sender).ReportProgress(0, progress);

                var path = Path.Combine(directory, resource.FileName);

                try
                {
                    webClient.DownloadFile(new Uri(resource.Url), path);
                }
                catch (Exception)
                {

                }
            }

            ((BackgroundWorker)sender).ReportProgress(0, "Загрузка завершена.");
        }
    }
}
