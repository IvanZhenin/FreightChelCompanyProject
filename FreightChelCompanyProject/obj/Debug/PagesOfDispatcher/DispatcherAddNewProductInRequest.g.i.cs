﻿#pragma checksum "..\..\..\PagesOfDispatcher\DispatcherAddNewProductInRequest.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "E40C5EAFF170AB75D7ABF6EA957F489F91B9CD934A8C307A6CB619BCF2E354C6"
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
    /// DispatcherAddNewProductInRequest
    /// </summary>
    public partial class DispatcherAddNewProductInRequest : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\..\PagesOfDispatcher\DispatcherAddNewProductInRequest.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock textBlockPageStatus;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\PagesOfDispatcher\DispatcherAddNewProductInRequest.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox inputNumRequest;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\PagesOfDispatcher\DispatcherAddNewProductInRequest.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox choseProduct;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\PagesOfDispatcher\DispatcherAddNewProductInRequest.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox inputProduct;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\PagesOfDispatcher\DispatcherAddNewProductInRequest.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox inputQuantity;
        
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
            System.Uri resourceLocater = new System.Uri("/FreightChelCompanyProject;component/pagesofdispatcher/dispatcheraddnewproductinr" +
                    "equest.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\PagesOfDispatcher\DispatcherAddNewProductInRequest.xaml"
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
            this.textBlockPageStatus = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.inputNumRequest = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.choseProduct = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.inputProduct = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.inputQuantity = ((System.Windows.Controls.TextBox)(target));
            
            #line 44 "..\..\..\PagesOfDispatcher\DispatcherAddNewProductInRequest.xaml"
            this.inputQuantity.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.InputQuantityPreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 49 "..\..\..\PagesOfDispatcher\DispatcherAddNewProductInRequest.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonSaveClick);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 51 "..\..\..\PagesOfDispatcher\DispatcherAddNewProductInRequest.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonBackClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

