namespace Scaffolding
{
    using System;
    using System.Threading;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    // http://www.codeproject.com/Articles/11541/The-Simplest-C-Events-Example-Imaginable
    // http://msdn.microsoft.com/fr-fr/library/system.eventhandler(v=vs.110).aspx
    public class MetronomeTickEventScafolding
    {
        [TestMethod]
        [Ignore]
        public void ViewMetronomeEventTickPropagation()
        {
            Metronome m = new Metronome();
            Listener l = new Listener();
            l.Subscribe(m);
            m.Start();
        }
    }

    public class MetronomeTickArgs : EventArgs
    {
        public MetronomeTickArgs(int count)
        {
            Count = count;
        }

        public int Count { get; set; }
    }

    public class Metronome
    {
        public event EventHandler<MetronomeTickArgs> Tick;

        public void Start()
        {
            var args = new MetronomeTickArgs(0);
            while (true)
            {
                Thread.Sleep(3000);
                if (Tick != null)
                {
                    args.Count++;
                    Tick(this, args);
                }
            }
        }
    }

    public class Listener
    {
        public void Subscribe(Metronome m)
        {
            m.Tick += HeardIt;
        }

        private void HeardIt(object m, MetronomeTickArgs e)
        {
            var message = string.Format("HEARD IT! {0} times", e.Count);
            System.Diagnostics.Trace.Write(message + Environment.NewLine);
        }
    }
}
