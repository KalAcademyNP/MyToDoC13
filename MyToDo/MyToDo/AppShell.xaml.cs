using MyToDo.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using MyToDo.Models;

namespace MyToDo
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Add.BindingContext = new ToDo();
        }

    }
}
