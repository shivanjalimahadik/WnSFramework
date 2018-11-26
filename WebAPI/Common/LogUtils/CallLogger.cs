//-----------------------------------------------------------------------
// <copyright file="CallLogger.cs" company="SA Technology">
//     Copyright (c) SA Technology. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Common.LogUtils
{
    using System.IO;
    using System.Linq;
    using Castle.DynamicProxy;

    /// <summary>
    /// Logger class
    /// </summary>
    public class CallLogger : IInterceptor
    {
        /// <summary>
        /// Text writer variable
        /// </summary>
        TextWriter _output;

        /// <summary>
        /// Initializes a new instance of the <see cref="CallLogger" /> class.
        /// </summary>
        /// <param name="output">TextWrtier object</param>
        public CallLogger(TextWriter output)
        {
            _output = output;
        }

        /// <summary>
        /// Intercept method
        /// </summary>
        /// <param name="invocation">Invocation interface object</param>
        public void Intercept(IInvocation invocation)
        {
            _output.Write("Calling method {0} with parameters {1}... ",
              invocation.Method.Name,
              string.Join(", ", invocation.Arguments.Select(a => (a ?? "").ToString()).ToArray()));

            invocation.Proceed();

            _output.WriteLine("Done: result was {0}.", invocation.ReturnValue);
        }
    }
}