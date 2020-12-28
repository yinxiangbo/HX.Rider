using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace HX.Rider.Exception
{
    /// <summary>
    /// 恒星业务异常
    /// </summary>
    /// <remarks>
    /// https://msdn.microsoft.com/zh-cn/library/ms229007(v=vs.100).aspx
    /// </remarks>
    [Serializable]
    public class HXException : System.Exception
    {
        /// <summary>
        /// 异常编号
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 异常级别
        /// </summary>
        public HXExceptionLevel Level { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        public HXException()
            : base()
        { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="exceptionCode">异常编号</param>
        /// <param name="level">异常级别</param>
        public HXException(string exceptionCode, HXExceptionLevel level = HXExceptionLevel.Error)
            : base(exceptionCode)
        {
            this.Code = exceptionCode;
            this.Level = level;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="exceptionCode">异常编号</param>
        /// <param name="message">异常信息</param>
        /// <param name="level">异常级别</param>
        public HXException(string exceptionCode, string message, HXExceptionLevel level = HXExceptionLevel.Error)
            : base(message)
        {
            this.Code = exceptionCode;
            this.Level = level;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="exceptionCode">异常编号</param>
        /// <param name="innerException">内部异常</param>
        /// <param name="level">异常级别</param>
        public HXException(string exceptionCode, System.Exception innerException, HXExceptionLevel level = HXExceptionLevel.Error)
            : base(GetDefaultMessage(innerException), innerException)
        {
            this.Code = exceptionCode;
            this.Level = level;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="exceptionCode">异常编号</param>
        /// <param name="message">异常信息</param>
        /// <param name="innerException">内部异常</param>
        /// <param name="level">异常级别</param>
        public HXException(string exceptionCode, string message, System.Exception innerException, HXExceptionLevel level = HXExceptionLevel.Error)
            : base(message, innerException)
        {
            this.Code = exceptionCode;
            this.Level = level;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="exceptionCode">异常编号</param>
        /// <param name="context">上下文</param>
        /// <param name="level">异常级别</param>
        public HXException(string exceptionCode, IDictionary<string, string> context, HXExceptionLevel level = HXExceptionLevel.Error)
            : base(exceptionCode)
        {
            this.Code = exceptionCode;
            this.Level = level;
            InitData(context);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="exceptionCode">异常编号</param>
        /// <param name="message">异常信息</param>
        /// <param name="context">上下文</param>
        /// <param name="level">异常级别</param>
        public HXException(string exceptionCode, string message, IDictionary<string, string> context, HXExceptionLevel level = HXExceptionLevel.Error)
            : base(message)
        {
            this.Code = exceptionCode;
            this.Level = level;
            InitData(context);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="exceptionCode">异常编号</param>
        /// <param name="innerException">内部异常</param>
        /// <param name="context">上下文</param>
        /// <param name="level">异常级别</param>
        public HXException(string exceptionCode, System.Exception innerException, IDictionary<string, string> context, HXExceptionLevel level = HXExceptionLevel.Error)
            : base(GetDefaultMessage(innerException), innerException)
        {
            this.Code = exceptionCode;
            this.Level = level;
            InitData(context);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="exceptionCode">异常编号</param>
        /// <param name="message">异常信息</param>
        /// <param name="innerException">内部异常</param>
        /// <param name="context">上下文</param>
        /// <param name="level">异常级别</param>
        public HXException(string exceptionCode, string message, System.Exception innerException, IDictionary<string, string> context, HXExceptionLevel level = HXExceptionLevel.Error)
            : base(message, innerException)
        {
            this.Code = exceptionCode;
            this.Level = level;
            InitData(context);
        }

        /// <summary>
        /// 初始化上下文数据
        /// </summary>
        /// <param name="context">上下文</param>
        private void InitData(IDictionary<string, string> context)
        {
            if (context != null)
            {
                foreach (string item in context.Keys)
                {
                    if (this.Data.Contains(item) == false)
                        this.Data.Add(item, context[item]);
                }
            }
        }

        private static string GetDefaultMessage(System.Exception ex)
        {
            return ex == null ? "" : ex.Message;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="info">序列化信息</param>
        /// <param name="context">上下文</param>
        protected HXException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            this.Code = info.GetString("ExceptionCode");
            this.Level = (HXExceptionLevel)info.GetSingle("Level");
        }

        /// <summary>
        /// 获取对象数据
        /// </summary>
        /// <param name="info">序列化信息</param>
        /// <param name="context">上下文</param>
        [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("ExceptionCode", this.Code);
            info.AddValue("Level", this.Level);

            base.GetObjectData(info, context);
        }
    }
}
