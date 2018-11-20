using System;
using System.Collections.Generic;
using System.Text;

namespace CodeNodes.Core
{
    /// <summary>
    /// 建议的文档注释标记
    /// </summary>
    public class DocumentationComments
    {
        /// <summary>
        /// 计算两个整数 <paramref name="n1" /> , <paramref name="n2"/> 的和
        /// </summary>
        /// <returns>两个整数的和</returns>
        /// <param name="n1">一个int值</param>
        /// <param name="n2">一个int值</param>
        /// <exception cref="System.OverflowException">当两数之和大于int的最大值时抛出此异常.</exception>
        /// <example>
        /// 这是一个介绍如何使用<see cref="Add(int, int)"/>方法的示例
        /// <code>
        /// class TestClass
        /// {
        ///     static int Main()
        ///     {
        ///         return Add(1,2);
        ///     }
        /// }
        /// </code>
        /// </example>
        public double Add(int n1, int n2)
        {
            if ((n1 == int.MaxValue && n2 > 0) || (n2 == int.MaxValue && n1 > 0))
                throw new OverflowException();
            return n1 + n2;
        }

        /// <summary>
        /// 计算两个double类型数字 <paramref name="d1" /> , <paramref name="d2"/> 的和
        /// </summary>
        /// <returns>两个double类型数字的和</returns>
        /// <param name="d1">一个double值</param>
        /// <param name="d2">一个double值</param>
        /// <exception cref="System.OverflowException">当两数之和大于int的最大值时抛出此异常.</exception>
        /// <example>
        /// 这是一个介绍如何使用<see cref="Add(double, double)"/>方法的示例
        /// <code>
        /// class TestClass
        /// {
        ///     static int Main()
        ///     {
        ///         return Add(1.2,3.4);
        ///     }
        /// }
        /// </code>
        /// </example>
        public double Add(double d1, double d2)
        {
            if ((d1 == double.MaxValue && d2 > 0) || (d2 == double.MaxValue && d1 > 0))
                throw new OverflowException();
            return d1 + d2;
        }
    }
}
