using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TestTaskUsar.Core;
using TestTaskUsar.Core.Interfaces.Serivces;
using TestTaskUsar.Core.Services;

namespace TestTaskUsar.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly IHttpClientServiceImplementation _messageServceHttp;
        private readonly IFileService _fileService;
        private readonly IDialogService _dialogService;
        public Visibility LoadBarVisibility { get; set; }
        public Visibility DatePickerVisibility { get; set; } = Visibility.Hidden;
        public DateTime EndFilterDate { get; set; } = DateTime.Now;
        public DateTime StartFilterDate { get; set; } = DateTime.Now.AddDays(-365);
        public string MessageText { get; set; }
        public List<Message> MessagesList { get; set; }
        public ObservableCollection<Message> MessagesShowingList { get; set; }

        public MainViewModel(IHttpClientServiceImplementation messageServceHttp, IFileService fileService, IDialogService dialogService)
        {
            Task.Run(() => GetMessages());
            SendMessageCommand = new RelayCommand(() => SendCommand());
            FilterCheckBoxCheckedCommand = new RelayParameterizedCommand((obj) => ActivateFilter(obj));
            FilterChangedCommand = new RelayCommand(() => FilteringMessages());
            SaveAllMessagesToFileCommand = new RelayCommand(() => SaveAllMessages());
            _messageServceHttp = messageServceHttp;
            _fileService = fileService;
            _dialogService = dialogService;
        }

        private async void SendCommand()
        {
            if(string.IsNullOrEmpty(MessageText) || string.IsNullOrWhiteSpace(MessageText))
            {
                MessageBox.Show("Введите сообщение!","",MessageBoxButton.OK);
                return;
            }

            var messageForCreation = new Message();
            messageForCreation.SenderName = Environment.UserName;
            messageForCreation.Text = MessageText;

            var result = await _messageServceHttp.Create(messageForCreation);

            if(result != null)
            {
                MessagesShowingList.Add(result);
            }
        }

        private async void GetMessages()
        {
            var a = StartFilterDate;
            LoadBarVisibility = Visibility.Visible;

            var result = await _messageServceHttp.Get();

            if(result != null)
            {
                MessagesList = new List<Message>(result);
                MessagesShowingList = new ObservableCollection<Message>(MessagesList);
            }
            LoadBarVisibility = Visibility.Collapsed;
        }

        private void ActivateFilter(object value)
        {
            if((bool)value)
            {
                DatePickerVisibility = Visibility.Visible;
                FilteringMessages();
            }
            else 
            { 
                DatePickerVisibility = Visibility.Hidden; 
            }
        }

        private void FilteringMessages()
        {
            MessagesShowingList = new ObservableCollection<Message>(MessagesList.Where(m => m.CreationDate >= StartFilterDate && m.CreationDate <= EndFilterDate.AddMinutes(2)));
        }

        private void SaveAllMessages()
        {
            try
            {
                if (_dialogService.SaveFileDialog() == true)
                {
                    _fileService.Save(_dialogService.FilePath, MessagesShowingList.ToList());
                    _dialogService.ShowMessage("Файл сохранен");
                }
            }
            catch (Exception ex)
            {
                _dialogService.ShowMessage(ex.Message);
            }
        }


    

        public ICommand SendMessageCommand { get; set; }
        public ICommand FilterCheckBoxCheckedCommand { get; set; }
        public ICommand FilterChangedCommand { get; set; }
        public ICommand SaveAllMessagesToFileCommand { get; set; }
    }
}
