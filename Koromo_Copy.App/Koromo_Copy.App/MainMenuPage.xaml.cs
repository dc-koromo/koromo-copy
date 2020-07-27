﻿// This source code is a part of Koromo Copy Project.
// Copyright (C) 2019. dc-koromo. Licensed under the MIT Licence.

using Koromo_Copy.App.Models;
using Koromo_Copy.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Koromo_Copy.App
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainMenuPage : ContentPage
    {
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        List<MainMenuItem> menuItems;
        public MainMenuPage()
        {
            InitializeComponent();

            menuItems = new List<MainMenuItem>
            {
                new MainMenuItem {Id = MenuItemType.Downloader, Title="다운로더", Icon = IconPack.CloudDownloadOutline },
                //new MainMenuItem {Id = MenuItemType.Search, Title="검색기", Icon= IconPack.Magnify },
                new MainMenuItem {Id = MenuItemType.Log, Title="로그", Icon= IconPack.PostOutline },
                new MainMenuItem {Id = MenuItemType.Settings, Title="설정", Icon= IconPack.Settings },
                new MainMenuItem {Id = MenuItemType.About, Title="이 어플에 관하여", Icon= IconPack.InformationOutline },
#if DEBUG
                //new MainMenuItem {Id = MenuItemType.Test, Title="테스트", Icon= IconPack.BottleTonicSkull }
#endif
            };

            ListViewMenu.ItemsSource = menuItems;

            ListViewMenu.SelectedItem = menuItems[0];
            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;

                var id = (int)((MainMenuItem)e.SelectedItem).Id;
                await RootPage.NavigateFromMenu(id);
            };

            VersionText.Text += " " + Version.Text;
        }

        public void SizeChange()
        {
            if (Title.Margin.Top == 128)
            {
                Title.Margin = new Thickness(8, 16, 8, 0);
                VersionText.Margin = new Thickness(8, 2, 8, 8);
            }
            else
            {
                Title.Margin = new Thickness(8, 128, 8, 0);
                VersionText.Margin = new Thickness(8, 2, 8, 32);
            }
        }
    }
}