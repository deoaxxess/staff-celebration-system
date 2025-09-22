using System;
using System.Collections.Generic;
using System.Text;

namespace StaffCelebrationSystemAPI.Models.Formats
{
    public static class ResponseFormat
    {
        public static object SuccessMessage(string message)
        {
            return new
            {
                status = "SUCCESS",
                message = message
            };
        }

        public static object SuccessMessageWithData(string message, object data)
        {
            return new
            {
                status = "SUCCESS",
                message = message,
                data = data
            };
        }

        public static object FailureMessage(string message)
        {
            return new
            {
                status = "FAILED",
                message = message
            };
        }

        public static object FailureMessageWithData(string message, object data)
        {
            return new
            {
                status = "FAILED",
                message = message,
                data = data,
            };
        }


    }
}
