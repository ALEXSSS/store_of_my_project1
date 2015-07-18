using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsApplication4
{
    class ProgressThread
    {
       public delegate void ProgressB();
       public ProgressB MyDelegate;
       public ProgressB MyDelegate1;
       public ProgressBar progressBar;
       public ProgressThread(ProgressBar progressBar)
       {
           MyDelegate = new ProgressB(Load);
           MyDelegate1 = new ProgressB(clear);
           this.progressBar = progressBar; 
       }
        public void Load()
        {
            progressBar.Value++;
        }
        public void clear()
        {
            progressBar.Value=0;
        }
    }
}
