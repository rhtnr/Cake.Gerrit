using System;
using System.Collections.Generic;
using System.Text;

namespace Cake.Gerrit.Models.Executor
{
    public class CommandResult
    {
        public int ExitStatus { get; set; }
        public string Error { get; set; }
        public string Output { get; set; }
        public string ExtendedOutput { get; set; }

        override public string ToString()
        {
            return $"EXITSTATUS=[{ExitStatus}] OUTPUT=[{Output}] ERROR-[{Error}] EXTENDEDOUTPUT=[{ExtendedOutput}]";
        }
    }
}

