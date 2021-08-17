using log4net.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TracingNetCore.Core.CrossCuttingConcerns.Logging.Log4Net
{
    [Serializable]
    public class SerializableLogEvent
    {
        private LoggingEvent loggingEvent;

        public SerializableLogEvent(LoggingEvent loggingEvent)
        {
            this.loggingEvent = loggingEvent;
        }

        public object Message => this.loggingEvent.MessageObject;
    }
}
