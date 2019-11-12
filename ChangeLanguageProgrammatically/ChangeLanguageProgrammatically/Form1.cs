using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChangeLanguageProgrammatically
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                InputLanguage currentLang = InputLanguage.CurrentInputLanguage;
                textBox1.Text = currentLang.Culture.EnglishName;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void changeBtn_Click(object sender, EventArgs e)
        {
            try
            {
                InputLanguage lang = InputLanguage.CurrentInputLanguage;
                if (lang.Culture.ThreeLetterISOLanguageName == "eng")
                {
                    ChangeLanguage("greek");
                    InputLanguage currentLang = InputLanguage.CurrentInputLanguage;
                    textBox1.Text = currentLang.Culture.EnglishName;
                }
                else
                {
                    ChangeLanguage("english");
                    InputLanguage currentLang = InputLanguage.CurrentInputLanguage;
                    textBox1.Text = currentLang.Culture.EnglishName;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }  

        // function for changing the language programmatically
        private void ChangeLanguage(string lanqName)
        {
            foreach (InputLanguage lang in InputLanguage.InstalledInputLanguages)
            {
                // if language exist
                if (lang.Culture.EnglishName.ToLower().StartsWith(lanqName))
                {
                    InputLanguage.CurrentInputLanguage = lang;
                    break;
                }
            }
        }
    }
}
