﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
using PRM.Core.Model;
using PRM.Core.Protocol.Runner;
using PRM.Core.Protocol.Runner.Default;

namespace PRM.View.ProtocolConfig
{
    public partial class ExternalRunnerConfiger : UserControl
    {
        public static readonly DependencyProperty RunnerProperty =
            DependencyProperty.Register("Runner", typeof(ExternalRunner), typeof(ExternalRunnerConfiger),
                new PropertyMetadata(null, new PropertyChangedCallback(OnDataChanged)));

        private static void OnDataChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var value = (ExternalRunner)e.NewValue;
            ((ExternalRunnerConfiger)d).DataContext = value;
        }

        public ExternalRunner Runner
        {
            get => (ExternalRunner)GetValue(RunnerProperty);
            set => SetValue(RunnerProperty, value);
        }

        public ExternalRunnerConfiger()
        {
            InitializeComponent();
        }
    }
}
