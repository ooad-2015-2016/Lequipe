﻿#pragma checksum "C:\Users\Emir\Desktop\Lequipe\Projekat\MyMovieCollectionProjekat\MyMovieCollectionProjekat\MyMovieCollection\Views\Pocetna.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "C2A15B49C14E8B133775CD42E5FE3A7F"
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
    partial class Pocetna : 
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
                    this.button = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 47 "..\..\..\..\MyMovieCollection\Views\Pocetna.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.button).Click += this.button_Click;
                    #line default
                }
                break;
            case 2:
                {
                    this.Pretraga_Filmova = (global::Windows.UI.Xaml.Controls.Button)(target);
                }
                break;
            case 3:
                {
                    this.Uredi_Profil = (global::Windows.UI.Xaml.Controls.Button)(target);
                }
                break;
            case 4:
                {
                    this.button_Copy4 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 50 "..\..\..\..\MyMovieCollection\Views\Pocetna.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.button_Copy4).Click += this.button_Copy4_Click;
                    #line default
                }
                break;
            case 5:
                {
                    this.textBlock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 6:
                {
                    this.textBlock2 = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 7:
                {
                    this.button1 = (global::Windows.UI.Xaml.Controls.Button)(target);
                }
                break;
            case 8:
                {
                    this.button2 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 58 "..\..\..\..\MyMovieCollection\Views\Pocetna.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.button2).Click += this.button2_Click;
                    #line default
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

