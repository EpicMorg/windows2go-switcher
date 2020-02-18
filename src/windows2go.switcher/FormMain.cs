using Microsoft.Win32;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace windows2go.switcher {
    public partial class FormMain : Form {
        
        static RegistryKey BaseKey = Registry.LocalMachine;
        static RegistryKey SYSTEMKey = BaseKey.OpenSubKey("SYSTEM");
        static RegistryKey CurrentControlSetKey = SYSTEMKey.OpenSubKey("CurrentControlSet");
        static RegistryKey ControlKey = CurrentControlSetKey.OpenSubKey("Control",true);

        int CurrentStateCode; //-1 not exists, 0 normal,  1 portable, 2 wrond  dword,  3 not a  dword

        public FormMain() {
            InitializeComponent();
            UACSecurity.AddShieldToButton(buttonSet);

            if (UACSecurity.IsAdmin()) this.Text += " (Administrator)";
            
        }

        private void FormMain_Load(object sender, EventArgs e) {
            try {
                TryToGetValue();
            } catch (Exception ex) {
                MessageBox.Show("Error!" + Environment.NewLine + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void TryToGetValue() {
            object PortableOperatingSystemValue = ControlKey.GetValue("PortableOperatingSystem");
            if(PortableOperatingSystemValue != null) {
                switch (ControlKey.GetValueKind("PortableOperatingSystem")) {
                    case RegistryValueKind.String:
                    case RegistryValueKind.ExpandString:
                        //MessageBox.Show("ValueST = " + PortableOperatingSystemValue);
                        inBadTypeState();
                        break;
                    case RegistryValueKind.Binary:
                        /*
                        foreach (byte b in (byte[])PortableOperatingSystemValue) {
                            MessageBox.Show("{0:x2} " + b);
                        }
                        Console.WriteLine();
                        */
                        inBadTypeState();
                        break;
                    case RegistryValueKind.DWord: 
                        //if "PortableOperatingSystem" and it;s value not normal. example = "PortableOperatingSystem=42"
                        if ((PortableOperatingSystemValue.ToString() != "0") && (PortableOperatingSystemValue.ToString() != "1")) {
                            //MessageBox.Show("ValueDW = " + Convert.ToString((Int32)PortableOperatingSystemValue));
                            inWrongValueState();
                        } else if (PortableOperatingSystemValue.ToString() == "0") {
                            inNormalValueState();
                            //MessageBox.Show(PortableOperatingSystemValue.ToString(), "");
                        } else if(PortableOperatingSystemValue.ToString() == "1") {
                            inPortableValueState();
                            //MessageBox.Show(PortableOperatingSystemValue.ToString(), "");
                        }
                        break;
                    case RegistryValueKind.QWord:
                        //MessageBox.Show("ValueQW = " + Convert.ToString((Int64)PortableOperatingSystemValue));
                        inBadTypeState();
                        break;
                    case RegistryValueKind.MultiString:
                        foreach (string s in (string[])PortableOperatingSystemValue) {
                            //MessageBox.Show("[{0:s}], ", s);
                            inBadTypeState();
                        }
                        Console.WriteLine();
                        break;
                    default:
                        //MessageBox.Show("Value = (Unknown)");
                        inBadTypeState();
                        break;
                }

            } else {
                inNotExistsState();
            }





            /*
            try {
                
            } catch (Exception ex) {
                    inUnexpectedlState();
                    MessageBox.Show(ex.ToString(), "");
            }
            */
            }

        #region states

        private void inNotExistsState() {
            buttonSet.Enabled = true;
            buttonSet.Text = @"Forced set to normal?";
            labelState.Text = "\"PortableOperatingSystem\" not found in registry." + Environment.NewLine +
                              "It's equals normal mode.";
            labelState.ForeColor = Color.OrangeRed;
            toolStripStatusLabelRegValue.Image = Properties.Resources.cancel;
            toolStripStatusLabelRegValue.Text = "";
            CurrentStateCode = -1;
        }

        private void inNormalValueState() {
            buttonSet.Enabled = true;
            buttonSet.Text = @"Set Portable";
            labelState.Text = "System running in normal mode." + Environment.NewLine + 
                "You able to switch to another.";
            labelState.ForeColor = Color.LimeGreen;
            toolStripStatusLabelRegValue.Image = null;
            toolStripStatusLabelRegValue.Text = "0";
            CurrentStateCode = 0; 
        }

        private void inPortableValueState() {
            buttonSet.Enabled = true;
            buttonSet.Text = @"Set Normal";
            labelState.Text = "System running in \"Windows To Go\" mode." + Environment.NewLine +
                "You able to switch to another.";
            labelState.ForeColor = Color.Crimson;
            toolStripStatusLabelRegValue.Image = null;
            toolStripStatusLabelRegValue.Text = "1";
            CurrentStateCode = 1;
        }

        private void inWrongValueState() {
            buttonSet.Enabled = true;
            buttonSet.Text = @"Forced set to normal?";
            labelState.Text = "DWORD \"PortableOperatingSystem\" have wrong value." + Environment.NewLine +
                              "It's strange but equals normal mode.";
            labelState.ForeColor = Color.OrangeRed;
            toolStripStatusLabelRegValue.Image = Properties.Resources.cancel;
            toolStripStatusLabelRegValue.Text = "";
            CurrentStateCode = 2;
        }

        private void inBadTypeState() {
            buttonSet.Enabled = true;
            buttonSet.Text = @"Forced set to normal?";
            labelState.Text = "\"PortableOperatingSystem\" is not a DWORD." + Environment.NewLine +
                              "It's strange but equals normal mode.";
            labelState.ForeColor = Color.OrangeRed;
            toolStripStatusLabelRegValue.Image = Properties.Resources.cancel;
            toolStripStatusLabelRegValue.Text = "";
            CurrentStateCode = 3;
        }
        #endregion

     
        private void SetNormalState() { 
                ControlKey.SetValue("PortableOperatingSystem", 0, RegistryValueKind.DWord); 
        }
       
        private void ForcedFixNormalState() { 
                ControlKey.DeleteValue("PortableOperatingSystem");
                SetNormalState();
          
        }

        private void SetPortableState() { 
                ControlKey.SetValue("PortableOperatingSystem", 1, RegistryValueKind.DWord);
         
        }


        /* 
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
          

         */

        private void buttonSetNormal_Click(object sender, EventArgs e) {
            // Registry.SetValue(keyName, "PortableOperatingSystem", 0);
            // FullRegistryCheck();
            switch (CurrentStateCode) {
                //case when it not exists yet
                case -1:
                    try {
                        SetNormalState();
                        MessageBox.Show("Succuess!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    } catch (Exception ex) {
                        MessageBox.Show("Error!" + Environment.NewLine + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    
                    break;
                //case when it in normal mode
                case 0:
                    try {
                        SetPortableState();
                        MessageBox.Show("Succuess!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    } catch (Exception ex) {
                        MessageBox.Show("Error!" + Environment.NewLine + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    break;
                //case when it in portable mode
                case 1:
                    try {
                        SetNormalState();
                        MessageBox.Show("Succuess!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    } catch (Exception ex) {
                        MessageBox.Show("Error!" + Environment.NewLine + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    break;
                //case when wrond  dword value
                case 2:
                    try {
                        SetNormalState();
                        MessageBox.Show("Succuess!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    } catch (Exception ex) {
                        MessageBox.Show("Error!" + Environment.NewLine + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    break;
                //case when it is not an dwrond
                case 3:
                    try {
                        ForcedFixNormalState();
                        MessageBox.Show("Succuess!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    } catch (Exception ex) {
                        MessageBox.Show("Error!" + Environment.NewLine + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    break;
            }
            try {
                TryToGetValue();
            } catch (Exception ex) {
                MessageBox.Show("Error!" + Environment.NewLine + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } 
        }
    }
}
