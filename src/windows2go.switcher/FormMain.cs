using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace windows2go.switcher {
    public partial class FormMain : Form {

        RegistryKey key = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Default);

        const string keyName ="HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control";

        public FormMain() {
            InitializeComponent();
            UACSecurity.AddShieldToButton(buttonSetNormal);
            UACSecurity.AddShieldToButton(buttonSetPortable);
            //  if (!UACSecurity.IsAdmin()) {
            //      
            //     
            //  } else
            //      this.Text += " (Administrator)";
        }

        bool PortableState;
        bool KeyExists;
        bool unExpected;

        private void FormMain_Load(object sender, EventArgs e) {
            FullRegistryCheck();
        }

        private void FullRegistryCheck() {
            GetState();
            if (!KeyExists) {
                inUnexpectedlState();
            } else {
                switch (PortableState) {
                    case true:
                        inPortableState();
                        break;
                    case false:
                        inNormalState();
                        break;
                    default:
                        inUnexpectedlState();
                        break;
                }
            }
        }

        private void GetState() {

            RegistryKey key = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry32);
            key = key.OpenSubKey(@"SYSTEM\CurrentControlSet\Control", true);
            //check for exists "PortableOperatingSystem"
            if (key != null) {
                switch (key.GetValue("PortableOperatingSystem")) {
                    case 0:
                        PortableState = true;
                        KeyExists = true;
                        break;
                    case 1:
                        PortableState = false;
                        KeyExists = true;
                        break; 
                    default:
                        PortableState = false;
                        KeyExists = false;
                        break;
                }
            } 
           
        }
        private void inNormalState() {
            buttonSetNormal.Enabled = false;
            buttonSetPortable.Enabled = true;
            labelState.Text = @"You are in normal mode";
            labelState.ForeColor = Color.LimeGreen;
            unExpected = false;
        }
        private void inPortableState() {
            buttonSetNormal.Enabled = true;
            buttonSetPortable.Enabled = false;
            labelState.Text = @"You are in portable (Windows To Go) mode";
            labelState.ForeColor = Color.Crimson;
            unExpected = false;
        }
        private void inUnexpectedlState() {
            buttonSetNormal.Enabled = true;
            buttonSetPortable.Enabled = false;
            buttonSetNormal.Text = @"Forced set to normal?";
            labelState.Text = "Maby DWORD \"PortableOperatingSystem\" not found in registry or have wrong value or type." +Environment.NewLine+
                              "sIt equals normal mode.";
            labelState.ForeColor = Color.OrangeRed;
            unExpected = true;
        }

        private void buttonSetNormal_Click(object sender, EventArgs e) {
            Registry.SetValue(keyName, "PortableOperatingSystem", 0);
            FullRegistryCheck();



            
        }

        private void buttonSetPortable_Click(object sender, EventArgs e) {
            Registry.SetValue(keyName, "PortableOperatingSystem", 1); 


        }
    }
}
