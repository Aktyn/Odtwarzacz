﻿#pragma checksum "..\..\Playlista.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "036D100E990E3C8BD47D0BF9BEBA253176181779429069E7E38E252F2A34C371"
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
    /// Playlista
    /// </summary>
    public partial class Playlista : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\Playlista.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button PrzyciskDodaj;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\Playlista.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button PrzyciskWczytaj;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\Playlista.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button PrzyciskZapisz;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\Playlista.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label NazwaPlaylisty;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\Playlista.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel lista_piosenek;
        
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
            System.Uri resourceLocater = new System.Uri("/Odtwarzacz;component/playlista.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Playlista.xaml"
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
            this.PrzyciskDodaj = ((System.Windows.Controls.Button)(target));
            
            #line 10 "..\..\Playlista.xaml"
            this.PrzyciskDodaj.Click += new System.Windows.RoutedEventHandler(this.PrzyciskDodaj_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.PrzyciskWczytaj = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\Playlista.xaml"
            this.PrzyciskWczytaj.Click += new System.Windows.RoutedEventHandler(this.PrzyciskWczytaj_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.PrzyciskZapisz = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\Playlista.xaml"
            this.PrzyciskZapisz.Click += new System.Windows.RoutedEventHandler(this.PrzyciskZapisz_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.NazwaPlaylisty = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.lista_piosenek = ((System.Windows.Controls.StackPanel)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

