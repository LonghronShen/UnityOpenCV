﻿/*
 * (C) 2008-2012 Schima
 * This code is licenced under the LGPL.
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
    /// OpenCvSharpから投げられる例外
    /// </summary>
#else
    /// <summary>
    /// The exception that is thrown by OpenCvSharp. 
    /// </summary>
#endif
    public class OpenCvSharpException : ApplicationException
    {
        /// <summary>
        /// 
        /// </summary>
        public OpenCvSharpException()
            : base()
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public OpenCvSharpException(string message)
            : base(message)
        { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageFormat"></param>
        /// <param name="args"></param>
        public OpenCvSharpException(string messageFormat, params object[] args)
            : base(string.Format(messageFormat, args))
        { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public OpenCvSharpException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
