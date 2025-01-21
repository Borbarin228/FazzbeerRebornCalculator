using Plugin.Maui.Audio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FazzbeerRebornCalculator
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public enum Status { Minus, Plus, Multipl, Devide, Persent, None }
        private string _leftOp = "0";
        private string _rightOp = "0";
        private string _operations;
        public Status status = Status.None;
        private bool isChanged = false;
        private bool _scream = false;
        private IAudioManager audioManager = new AudioManager();
        public ICommand add { get; }
        public string operations
        {
            get => _operations;
            set
            {
                _operations = value;
                OnPropertyChanged();
            }
        }
        public bool scream
        {
            get => _scream;
            set
            {
                _scream = value;
                OnPropertyChanged();
            }

        }

        public string result
        {
            get => _rightOp;
            set
            {
                if (isChanged)
                {
                    _rightOp = value;
                }
                else
                {
                    _rightOp = value.Substring(value.Length - 1);
                    isChanged = true;
                }


                OnPropertyChanged();
            }
        }



        public ICommand clean { get; }
        public ICommand delOnce { get; }
        public ICommand changeSign { get; }
        public ICommand dot { get; }
        public ICommand plus { get; }
        public ICommand minus { get; }
        public ICommand multipl { get; }
        public ICommand divide { get; }
        public ICommand persent { get; }
        public ICommand equal { get; }
        

        private void ExecuteAdd(string parameter)
        {
            AudioPlayerViewModel audioPlayerViewModel = new AudioPlayerViewModel(audioManager);
            audioPlayerViewModel.PlayAudio("buttonSound.mp3", false);
            
            switch (parameter)
            {
                case "button0":
                    result = addNum(result, "0");
                    break;
                case "button1":
                    result = addNum(result, "1");
                    break;
                case "button2":
                    result = addNum(result, "2");
                    break;
                case "button3":
                    result = addNum(result, "3");
                    break;
                case "button4":
                    result = addNum(result, "4");
                    break;
                case "button5":
                    result = addNum(result, "5");
                    break;
                case "button6":
                    result = addNum(result, "6");
                    break;
                case "button7":
                    result = addNum(result, "7");
                    break;
                case "button8":
                    result = addNum(result, "8");
                    break;
                case "button9":
                    result = addNum(result, "9");
                    break;
                default:
                    break;
            }
        }


        private async Task Screamer()
        {
            AudioPlayerViewModel audioPlayerViewModel = new AudioPlayerViewModel(audioManager);
            audioPlayerViewModel.PlayAudio("tmp.mp3", false);
            await Task.Delay(5500); // Ожидаем 5 секунд
            scream = true; // Устанавливаем значение
            await Task.Delay(4600);
            scream = false;
        }
        public string parseOperation(string leftOp, string rightOp, Status state)
        {

            string tmp = "";
            switch (state)
            {

                case Status.None:
                    tmp = result;
                    break;
                case Status.Multipl:
                    tmp = (Double.Parse(leftOp) * Double.Parse(rightOp)).ToString();
                    _leftOp = operations.Substring(0, operations.Length - 2);
                    result = tmp;
                    break;
                case Status.Plus:
                    tmp = (Double.Parse(leftOp) + Double.Parse(rightOp)).ToString();
                    _leftOp = operations.Substring(0, operations.Length);
                    result = tmp;
                    break;
                case Status.Minus:
                    tmp = (Double.Parse(leftOp) - Double.Parse(rightOp)).ToString();
                    _leftOp = operations.Substring(0, operations.Length);
                    result = tmp;
                    break;
                case Status.Persent:
                    tmp = (100 / Double.Parse(rightOp) * Double.Parse(leftOp)).ToString();
                    _leftOp = operations.Substring(0, operations.Length);
                    result = tmp;
                    break;
                case Status.Devide:
                    tmp = (Double.Parse(leftOp) / Double.Parse(rightOp)).ToString();
                    _leftOp = operations.Substring(0, operations.Length - 2);
                    result = tmp;
                    break;
            }
            if (tmp.Length > 2 && tmp.Substring(tmp.Length - 1) == ",")
            {
                tmp = tmp.Substring(0, tmp.Length - 1);
            }
            if (tmp == "1987")
            {
                Screamer();

            }

            return tmp;
        }
        public string addNum(string data, string addNewString)
        {
            AudioPlayerViewModel audioPlayerViewModel = new AudioPlayerViewModel(audioManager);
            audioPlayerViewModel.PlayAudio("buttonSound.mp3", false);
            if (data != "0")
            {
                data += addNewString;
            }
            else
            {
                data = addNewString;
            }

            return data;
        }
        public MainPageViewModel()
        {
            add = new Command<string>((parameter) => ExecuteAdd(parameter));
            _leftOp = "0";
            _rightOp = "0";
            status = Status.None;
            isChanged = false;
            _scream = false;
            clean = new Command(() =>
            {
                AudioPlayerViewModel audioPlayerViewModel = new AudioPlayerViewModel(audioManager);
                audioPlayerViewModel.PlayAudio("buttonSound.mp3", false);
                result = "0";
                operations = "";
                status = Status.None;

            });
            delOnce = new Command(() =>
            {
                AudioPlayerViewModel audioPlayerViewModel = new AudioPlayerViewModel(audioManager);
                audioPlayerViewModel.PlayAudio("buttonSound.mp3", false);
                if (result == "0") { result = "0"; }
                else if (result.Substring(0, 1) == "-" && result.Length == 2)
                {
                    result = result.Substring(0, result.Length - 2);
                }
                if (result == "-0,")
                {
                    result = result.Substring(1, result.Length - 1);
                }
                else
                {
                    result = result.Substring(0, result.Length - 1);
                }
                if (result == "") { result = "0"; }

            });
            changeSign = new Command(() =>
            {
                AudioPlayerViewModel audioPlayerViewModel = new AudioPlayerViewModel(audioManager);
                audioPlayerViewModel.PlayAudio("buttonSound.mp3", false);
                if (result.Substring(0, 1) == "-")
                {
                    result = result.Substring(1, result.Length - 1);
                }
                else if (result != "0" && result != "0,")
                {
                    string sign = "-";
                    sign += result.Substring(0, result.Length);
                    result = sign;
                }
            });
            dot = new Command(() =>
            {
                AudioPlayerViewModel audioPlayerViewModel = new AudioPlayerViewModel(audioManager);
                audioPlayerViewModel.PlayAudio("buttonSound.mp3", false);
                if (!result.Contains(",") && isChanged != false)
                {
                    result += ",";
                }
            });
            plus = new Command(() =>
            {
                AudioPlayerViewModel audioPlayerViewModel = new AudioPlayerViewModel(audioManager);
                audioPlayerViewModel.PlayAudio("buttonSound.mp3", false);
                if (status == Status.None)
                {
                    operations = result + " +";
                    _leftOp = _rightOp;
                    status = Status.Plus;

                }
                else
                {
                    isChanged = true;
                    operations = parseOperation(_leftOp, result, status) + "+";
                    _leftOp = _rightOp;
                    status = Status.Plus;
                }
                isChanged = false;


            });
            minus = new Command(() =>
            {
                AudioPlayerViewModel audioPlayerViewModel = new AudioPlayerViewModel(audioManager);
                audioPlayerViewModel.PlayAudio("buttonSound.mp3", false);
                if (status == Status.None)
                {
                    operations = result + " -";
                    _leftOp = _rightOp;
                    status = Status.Minus;

                }
                else
                {
                    isChanged = true;
                    operations = parseOperation(_leftOp, result, status) + "-";
                    _leftOp = _rightOp;
                    status = Status.Minus;

                }
                isChanged = false;


            });
            multipl = new Command(() =>
            {
                AudioPlayerViewModel audioPlayerViewModel = new AudioPlayerViewModel(audioManager);
                audioPlayerViewModel.PlayAudio("buttonSound.mp3", false);
                if (status == Status.None)
                {
                    isChanged = true;
                    operations = result + " *";
                    _leftOp = _rightOp;
                    status = Status.Multipl;

                }
                else
                {
                    isChanged = true;
                    operations = parseOperation(_leftOp, result, status) + " *";
                    _leftOp = _rightOp;
                    status = Status.Multipl;

                }
                isChanged = false;



            });
            divide = new Command(() =>
            {
                AudioPlayerViewModel audioPlayerViewModel = new AudioPlayerViewModel(audioManager);
                audioPlayerViewModel.PlayAudio("buttonSound.mp3", false);
                if (status == Status.None)
                {
                    operations = result + " /";
                    _leftOp = _rightOp;
                    status = Status.Devide;
                }
                else
                {
                    isChanged = true;
                    operations = parseOperation(_leftOp, result, status) + " /";
                    _leftOp = _rightOp;
                    status = Status.Devide;
                }

                isChanged = false;


            });
            persent = new Command(() =>
            {
                AudioPlayerViewModel audioPlayerViewModel = new AudioPlayerViewModel(audioManager);
                audioPlayerViewModel.PlayAudio("buttonSound.mp3", false);
                if (status == Status.None)
                {
                    operations = result + " %";
                    _leftOp = _rightOp;
                    status = Status.Persent;
                }
                else
                {
                    isChanged = true;
                    operations = parseOperation(_leftOp, result, status) + " %";
                    _leftOp = _rightOp;
                    status = Status.Persent;
                }

                isChanged = false;


            });
            equal = new Command(() =>
            {
                AudioPlayerViewModel audioPlayerViewModel = new AudioPlayerViewModel(audioManager);
                audioPlayerViewModel.PlayAudio("buttonSound.mp3", false);
                isChanged = true;
                operations = parseOperation(_leftOp, result, status) + " =";
                status = Status.None;
                isChanged = false;

            });


        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }
    }
}
