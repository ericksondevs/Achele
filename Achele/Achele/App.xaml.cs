﻿using System;
using Xamarin.Forms;
using Achele.Views;
using Xamarin.Forms.Xaml;
using SQLitePCL;
using Achele.Data;
using System.IO;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace Achele
{
    public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();


			MainPage = new HomePage();
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}

        static DataBase database;

        public static DataBase Database
        {
            get
            {
                if (database == null)
                {
                    database = new DataBase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "AcheleDB.db3"));
                }
                return database;
            }
        }
    }
}