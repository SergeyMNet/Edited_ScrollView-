using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using App4.Enums;
using App4.Model;
using Xamarin.Forms;

namespace App4.ViewModels
{
    public class ItemVM : INotifyPropertyChanged
    {
        #region BaseProperties

        public int Id { get; set; }
        public string Title { get; set; }

        private int _status { get; set; }
        public int Status
        {
            get { return _status; }
            set
            {
                _status = value;

                if (_status == (int)StatusItem.Removed && IsVisible)
                {
                    IsVisible = false;
                }
                else if(!IsVisible)
                {
                    IsVisible = true;
                }

                OnPropertyChanged("Status");
                OnPropertyChanged("IsSelected");
                OnPropertyChanged("IsVisible");
                OnPropertyChanged("ColorRow");
            }
        }


        private int _workflow { get; set; }
        public int Workflow
        {
            get { return _workflow; }
            set
            {
                _workflow = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region ReadOnlyProperties

        public bool IsSelected
        {
            get
            {
                if (Status == (int)StatusItem.Selected)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        //public bool IsVisible
        //{
        //    get
        //    {
        //        if (Status == (int)StatusItem.Removed)
        //        {
        //            return false;
        //        }
        //        else
        //        {
        //            return true;
        //        }
        //    }
        //}

        public bool IsDone
        {
            get
            {
                if (Workflow == (int)WorkflowItem.Done)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }


        public int HeightRow => 50;
        public Color ColorRow
        {
            get
            {
                if (Status == (int)StatusItem.Selected)
                {
                    return Color.Lime;
                }
                else
                {
                    return Color.FromHex("#0075FF");
                }
            }
        }

        #endregion

        private bool _isVisible;
        public bool IsVisible
        {
            get { return _isVisible; }
            set
            {
                _isVisible = value;
                OnPropertyChanged();
            }
        }

        public Command Tapped { get; set; }


        public ItemVM(ItemModel m)
        {
            Id = m.Id;
            Title = m.Title;
            Status = m.Status;
            Workflow = m.Workflow;

            Tapped = new Command(TappedHeandler);
        }
        

        private void TappedHeandler(object obj)
        {
            Debug.WriteLine("----------[TappedHeandler]");

            if (this.Workflow == (int)WorkflowItem.Done)
            {
                this.Workflow = (int)WorkflowItem.Todo;
            }
            else
            {
                this.Workflow = (int)WorkflowItem.Done;
            }

            OnPropertyChanged("Workflow");
            OnPropertyChanged("IsDone");
        }


        #region PropertyChangedEventHandler

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
