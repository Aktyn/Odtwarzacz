﻿#pragma checksum "..\..\SterowanieOdtwarzaczem.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "18F5ACBBF0239DA0476E41074C9881FACEB0DF8D590442D25DF0BEEB9DADE0AF"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ten kod został wygenerowany przez narzędzie.
//     Wersja wykonawcza:4.0.30319.42000
//
//     Zmiany w tym pliku mogą spowodować nieprawidłowe zachowanie i zostaną utracone, jeśli
//     kod zostanie ponownie wygenerowany.
// </auto-generated>
//------------------------------------------------------------------------------

using Odtwarzacz;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace Odtwarzacz {
    
    
    /// <summary>
    /// SterowanieOdtwarzaczem
    /// </summary>
    public partial class SterowanieOdtwarzaczem : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\SterowanieOdtwarzaczem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button PrzyciskPauzy;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\SterowanieOdtwarzaczem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button GrajPoprzednia;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\SterowanieOdtwarzaczem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button GrajNastepna;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\SterowanieOdtwarzaczem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider PasekGlosnosci;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\SterowanieOdtwarzaczem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label ObecnyUtworInfo;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\SterowanieOdtwarzaczem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ProgressBar PasekPostepu;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Odtwarzacz;component/sterowanieodtwarzaczem.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\SterowanieOdtwarzaczem.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.PrzyciskPauzy = ((System.Windows.Controls.Button)(target));
            
            #line 10 "..\..\SterowanieOdtwarzaczem.xaml"
            this.PrzyciskPauzy.Click += new System.Windows.RoutedEventHandler(this.PrzyciskPauzy_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.GrajPoprzednia = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\SterowanieOdtwarzaczem.xaml"
            this.GrajPoprzednia.Click += new System.Windows.RoutedEventHandler(this.GrajPoprzednia_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.GrajNastepna = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\SterowanieOdtwarzaczem.xaml"
            this.GrajNastepna.Click += new System.Windows.RoutedEventHandler(this.GrajNastepna_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.PasekGlosnosci = ((System.Windows.Controls.Slider)(target));
            
            #line 13 "..\..\SterowanieOdtwarzaczem.xaml"
            this.PasekGlosnosci.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.PasekGlosnosci_ValueChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.ObecnyUtworInfo = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.PasekPostepu = ((System.Windows.Controls.ProgressBar)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

