﻿#pragma checksum "..\..\..\Views\PlanerView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "E33CECB02DF42B7CF719DDF5BB0032A357153A19"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Caliburn.Micro;
using Client.Views;
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


namespace Client.Views {
    
    
    /// <summary>
    /// PlanerView
    /// </summary>
    public partial class PlanerView : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 37 "..\..\..\Views\PlanerView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem UndoCommand;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\Views\PlanerView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem RedoCommand;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\Views\PlanerView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem CreatePlan;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\Views\PlanerView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem AddNewUser;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\Views\PlanerView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem ChangeUserData;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\Views\PlanerView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem Logout;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\Views\PlanerView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid PlanerModel_Planers;
        
        #line default
        #line hidden
        
        
        #line 104 "..\..\..\Views\PlanerView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ContentControl ActiveItem;
        
        #line default
        #line hidden
        
        
        #line 111 "..\..\..\Views\PlanerView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PretragaNaziv;
        
        #line default
        #line hidden
        
        
        #line 113 "..\..\..\Views\PlanerView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PretragaOpis;
        
        #line default
        #line hidden
        
        
        #line 117 "..\..\..\Views\PlanerView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.DatePickerTextBox PretragaPocetakOd;
        
        #line default
        #line hidden
        
        
        #line 121 "..\..\..\Views\PlanerView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.DatePickerTextBox PretragaPocetakDo;
        
        #line default
        #line hidden
        
        
        #line 126 "..\..\..\Views\PlanerView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.DatePickerTextBox PretragaKrajOd;
        
        #line default
        #line hidden
        
        
        #line 130 "..\..\..\Views\PlanerView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.DatePickerTextBox PretragaKrajDo;
        
        #line default
        #line hidden
        
        
        #line 132 "..\..\..\Views\PlanerView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Pretrazi;
        
        #line default
        #line hidden
        
        
        #line 133 "..\..\..\Views\PlanerView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button PonistiPretragu;
        
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
            System.Uri resourceLocater = new System.Uri("/Client;component/views/planerview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\PlanerView.xaml"
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
            this.UndoCommand = ((System.Windows.Controls.MenuItem)(target));
            return;
            case 2:
            this.RedoCommand = ((System.Windows.Controls.MenuItem)(target));
            return;
            case 3:
            this.CreatePlan = ((System.Windows.Controls.MenuItem)(target));
            return;
            case 4:
            this.AddNewUser = ((System.Windows.Controls.MenuItem)(target));
            return;
            case 5:
            this.ChangeUserData = ((System.Windows.Controls.MenuItem)(target));
            return;
            case 6:
            this.Logout = ((System.Windows.Controls.MenuItem)(target));
            return;
            case 7:
            this.PlanerModel_Planers = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 8:
            this.ActiveItem = ((System.Windows.Controls.ContentControl)(target));
            return;
            case 9:
            this.PretragaNaziv = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.PretragaOpis = ((System.Windows.Controls.TextBox)(target));
            return;
            case 11:
            this.PretragaPocetakOd = ((System.Windows.Controls.Primitives.DatePickerTextBox)(target));
            return;
            case 12:
            this.PretragaPocetakDo = ((System.Windows.Controls.Primitives.DatePickerTextBox)(target));
            return;
            case 13:
            this.PretragaKrajOd = ((System.Windows.Controls.Primitives.DatePickerTextBox)(target));
            return;
            case 14:
            this.PretragaKrajDo = ((System.Windows.Controls.Primitives.DatePickerTextBox)(target));
            return;
            case 15:
            this.Pretrazi = ((System.Windows.Controls.Button)(target));
            return;
            case 16:
            this.PonistiPretragu = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

