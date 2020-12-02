using System;

namespace Core.Common
{
    public class AgentNotFoundException : Exception
    {
        public AgentNotFoundException()
        {
        }

        public AgentNotFoundException(string message)
            : base(message)
        {
        }

        public AgentNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }

    public class AgecyNotFoundException : Exception
    {
        public AgecyNotFoundException()
        {
        }

        public AgecyNotFoundException(string message)
            : base(message)
        {
        }

        public AgecyNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }

    public class AgencyWasNotInserted : Exception
    {
        public AgencyWasNotInserted()
        {
        }

        public AgencyWasNotInserted(string message)
            : base(message)
        {
        }

        public AgencyWasNotInserted(string message, Exception inner)
            : base(message, inner)
        {
        }
    }

    public class AgentWasNotInserted : Exception
    {
        public AgentWasNotInserted()
        {
        }

        public AgentWasNotInserted(string message)
            : base(message)
        {
        }

        public AgentWasNotInserted(string message, Exception inner)
            : base(message, inner)
        {
        }
    }

    public class AgencyWasNotUpdated : Exception
    {
        public AgencyWasNotUpdated()
        {
        }

        public AgencyWasNotUpdated(string message)
            : base(message)
        {
        }

        public AgencyWasNotUpdated(string message, Exception inner)
            : base(message, inner)
        {
        }
    }

    public class AgentWasNotUpdated : Exception
    {
        public AgentWasNotUpdated()
        {
        }

        public AgentWasNotUpdated(string message)
            : base(message)
        {
        }

        public AgentWasNotUpdated(string message, Exception inner)
            : base(message, inner)
        {
        }
    }

    public class DeserializeDataException : Exception
    {
        public DeserializeDataException()
        {
        }

        public DeserializeDataException(string message)
            : base(message)
        {
        }

        public DeserializeDataException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }

    public class ImportDataException : Exception
    {
        public ImportDataException()
        {
        }

        public ImportDataException(string message)
            : base(message)
        {
        }

        public ImportDataException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }

}
