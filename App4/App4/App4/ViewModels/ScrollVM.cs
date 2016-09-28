using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using App4.Enums;
using App4.Model;
using Xamarin.Forms;

namespace App4.ViewModels
{
    public class ScrollVM : INotifyPropertyChanged
    {
        public List<ItemVM> Items { get; set; } = new List<ItemVM>();

        
        private bool _isShowAll = true;
        public bool IsShowAll
        {
            get { return _isShowAll; }
            set
            {
                _isShowAll = value;

                if (!_isShowAll)
                {
                    foreach (var item in Items)
                    {
                        if (!item.IsDone)
                            item.IsVisible = false;
                    }
                }
                else
                {
                    foreach (var item in Items)
                    {
                        if (item.Status != (int)StatusItem.Removed)
                            item.IsVisible = true;
                    }
                }

                OnPropertyChanged();
            }
        }

        
        public ScrollVM()
        {
            PrepareData();
        }
        


        private void PrepareData()
        {
            for (int i = 1; i <= 10; i++)
            {
                Items.Add(new ItemVM(new ItemModel()
                {
                    Id = i,
                    Title = "Item " + i,
                    Status = (int)StatusItem.Default,
                    Workflow = (int)WorkflowItem.Todo
                }));
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
