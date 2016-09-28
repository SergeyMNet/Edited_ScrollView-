using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using App4.Enums;
using Xamarin.Forms;

namespace App4.Model
{
    public class ItemModel
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public int Status { get; set; }
        public int Workflow { get; set; }
    }
}
