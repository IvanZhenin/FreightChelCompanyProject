﻿#pragma checksum "..\..\..\PagesOfDispatcher\DispatcherAssistPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "468F6C690129D3FF46EA8094ECB3A6D501B99800B0E8075094495C65085FF0FC"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using FreightChelCompanyProject.PagesOfDispatcher;
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


namespace FreightChelCompanyProject.PagesOfDispatcher {
    
    
    /// <summary>
    /// DispatcherAssistPage
    /// </summary>
    public partial class DispatcherAssistPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 26 "..\..\..\PagesOfDispatcher\DispatcherAssistPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox inputSearchNameClient;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\PagesOfDispatcher\DispatcherAssistPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox inputSearchPhoneClient;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\PagesOfDispatcher\DispatcherAssistPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dateGridClients;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\PagesOfDispatcher\DispatcherAssistPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox inputSearchNameProduct;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\PagesOfDispatcher\DispatcherAssistPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox choseSearchCategorieProduct;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\..\PagesOfDispatcher\DispatcherAssistPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dateGridProds;
        
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
            System.Uri resourceLocater = new System.Uri("/FreightChelCompanyProject;component/pagesofdispatcher/dispatcherassistpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\PagesOfDispatcher\DispatcherAssistPage.xaml"
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
            
            #line 9 "..\..\..\PagesOfDispatcher\DispatcherAssistPage.xaml"
            ((FreightChelCompanyProject.PagesOfDispatcher.DispatcherAssistPage)(target)).IsVisibleChanged += new System.Windows.DependencyPropertyChangedEventHandler(this.PageIsVisibleChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.inputSearchNameClient = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.inputSearchPhoneClient = ((System.Windows.Controls.TextBox)(target));
            
            #line 29 "..\..\..\PagesOfDispatcher\DispatcherAssistPage.xaml"
            this.inputSearchPhoneClient.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.InputSearchPhoneClientPreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 31 "..\..\..\PagesOfDispatcher\DispatcherAssistPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonSearchClient);
            
            #line default
            #line hidden
            return;
            case 5:
            this.dateGridClients = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 6:
            this.inputSearchNameProduct = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.choseSearchCategorieProduct = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 8:
            
            #line 64 "..\..\..\PagesOfDispatcher\DispatcherAssistPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonSearchProduct);
            
            #line default
            #line hidden
            return;
            case 9:
            this.dateGridProds = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

