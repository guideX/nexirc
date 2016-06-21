/*
//nexIRC 3.0.31
//05-30-2016 - guideX
using System;
using System.Collections.Generic;
using System.Windows.Forms;
namespace nexIRC.Business.Helpers {
    /// <summary>
    /// Irc Process
    /// </summary>
    public class IrcProcess {
        /// <summary>
        /// Process In Data Delegate
        /// </summary>
        /// <param name="statusIndex"></param>
        /// <param name="data"></param>
        private delegate void ProcessInDataDelegate(int statusIndex, string data);
        /// <summary>
        /// Busy
        /// </summary>
        private bool _busy = false;
        private List<process> _processes = new List<process>();
        private Timer withEventsField_processTimer;
        private Timer processTimer
        {
            get { return withEventsField_processTimer; }
            set
            {
                if (withEventsField_processTimer != null) {
                    withEventsField_processTimer.Tick -= processTimer_Tick;
                }
                withEventsField_processTimer = value;
                if (withEventsField_processTimer != null) {
                    withEventsField_processTimer.Tick += processTimer_Tick;
                }
            }

        }
        private struct process {
            public string pParam1;
            public int pStatusIndex;
        }

        private void processTimer_Tick(System.Object sender, System.EventArgs e) {
            int n = 0;
            int i = 0;
            List<process> processes = _processes;
            processes = new List<process>();
            if (_busy == true)
                return;
            if ((processes.Count != 0)) {
                for (i = 0; i <= processes.Count - 1; i++) {
                    if ((!string.IsNullOrEmpty(processes(i).pParam1))) {
                        n = n + 1;
                        ProcessInDataDelegate lProcessDataArrivalLine = new ProcessInDataDelegate(lProcessNumeric.ProcessDataArrivalLine);
                        try {
                            _busy = true;
                            // TODO: Integrarte lStatus
                            lStatus.GetObject(processes(i).pStatusIndex).sWindow.Invoke(lProcessDataArrivalLine, processes(i).pStatusIndex, processes(i).pParam1);
                            _busy = false;
                        } catch (Exception ex) {
                            _busy = false;
                            Initialize();
                        }
                        return;
                    }
                }
                processTimer.Enabled = false;
                return;
            }
        }

        public bool Busy
        {
            get { return _busy; }
            set { _busy = value; }
        }

        public void Add(int statusId, string data) {
            process process = new process();
            process.pParam1 = data;
            process.pStatusIndex = statusId;
            _processes.Add(process);
            if (processTimer.Enabled == false)
                processTimer.Enabled = true;
        }

        public void Initialize() {
            processTimer = new Timer();
            _processes = new List<process>();
        }
    }
}*/