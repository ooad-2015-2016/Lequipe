﻿#pragma checksum "C:\Users\model\Desktop\Lequipe\Projekat\MyMovieCollectionProjekat\MyMovieCollectionProjekat\MyMovieCollection\Views\AdministratorView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "74D88D2F39D7012AD11B6D48AD48F29A"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyMovieCollectionProjekat.MyMovieCollection.Views
{
    partial class AdministratorView : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                {
                    this.textBlock1 = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                    #line 60 "..\..\..\..\MyMovieCollection\Views\AdministratorView.xaml"
                    ((global::Windows.UI.Xaml.Controls.TextBlock)this.textBlock1).SelectionChanged += this.textBlock1_SelectionChanged;
                    #line default
                }
                break;
            case 2:
                {
                    this.textBlock3 = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 3:
                {
                    this.panelKorisnikDetalji = (global::Windows.UI.Xaml.Controls.RelativePanel)(target);
                }
                break;
            case 4:
                {
                    this.textBlock4 = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 5:
                {
                    this.button = (global::Windows.UI.Xaml.Controls.Button)(target);
                }
                break;
            case 6:
                {
                    this.button_Copy = (global::Windows.UI.Xaml.Controls.Button)(target);
                }
                break;
            case 7:
                {
                    this.buttstrelica = (global::Windows.UI.Xaml.Controls.Button)(target);
                }
                break;
            case 8:
                {
                    this.listaKorisnika = (global::Windows.UI.Xaml.Controls.ListBox)(target);
                }
                break;
            case 9:
                {
                    this.imeKorisnik = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 10:
                {
                    this.prezimeKorisnik = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 11:
                {
                    this.mailKorisnik = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 12:
                {
                    this.usernameKorisnik = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 13:
                {
                    this.registracijaKorisnik = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                    #line 73 "..\..\..\..\MyMovieCollection\Views\AdministratorView.xaml"
                    ((global::Windows.UI.Xaml.Controls.TextBlock)this.registracijaKorisnik).SelectionChanged += this.textBlock2_SelectionChanged;
                    #line default
                }
                break;
            case 14:
                {
                    this.image = (global::Windows.UI.Xaml.Controls.Image)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}
