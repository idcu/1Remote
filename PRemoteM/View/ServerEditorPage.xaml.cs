﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PRM.Core.Protocol;
using PRM.Core.Protocol.RDP;
using PRM.ViewModel;

namespace PRM.View
{
    /// <summary>
    /// ServerEditorPage.xaml 的交互逻辑
    /// </summary>
    public partial class ServerEditorPage : UserControl
    {
        private readonly VmServerEditorPage _vmServerEditorPage;
        public ServerEditorPage(VmServerEditorPage vm)
        {
            Debug.Assert(vm?.Server != null);
            InitializeComponent();
            _vmServerEditorPage = vm;
            DataContext = vm;
            // edit mode
            if (vm.Server.Id > 0 && vm.Server.GetType() != typeof(ProtocolServerNone))
            {
                LogoSelector.SetImg(vm.Server.IconImg);
                ColorPick.Color = vm.Server.MarkColor;
            }
            else
            // add mode
            {
                // TODO 研究子类之间的互相转换
                // TODO 随机选择LOGO
                //vm.Server = new ProtocolServerRDP();
                ColorPick.Color = Colors.White;
            }

            ColorPick.OnColorSelected += color => _vmServerEditorPage.Server.MarkColor = ColorPick.Color;
        }

        private void ImgLogo_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            PopupLogoSelector.IsOpen = true;
        }

        private void ButtonLogoSave_OnClick(object sender, RoutedEventArgs e)
        {
            if (_vmServerEditorPage?.Server != null && _vmServerEditorPage.Server.GetType() != typeof(ProtocolServerNone))
            {
                _vmServerEditorPage.Server.IconImg = LogoSelector.Logo;
                File.WriteAllText("img.txt",_vmServerEditorPage.Server.IconBase64);
            }
            PopupLogoSelector.IsOpen = false;
        }

        private void ButtonLogoCancel_OnClick(object sender, RoutedEventArgs e)
        {
            PopupLogoSelector.IsOpen = false;
        }
    }
}