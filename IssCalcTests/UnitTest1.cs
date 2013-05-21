﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IssCalcCore;
using IssCalcCore.Tokens;

namespace IssCalcTests
{
    [TestClass]
    public class ExpressionStringToStringArrayTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            string[] t = ExpressionParser_Accessor.ExpressionStringToStringArray("A + b ").ToArray();
            CollectionAssert.AreEqual(new string[] {"a","+","b"}, t);
        }

        [TestMethod]
        public void TestMethod2()
        {
            string[] t = ExpressionParser_Accessor.ExpressionStringToStringArray("a+bbbb").ToArray();
            CollectionAssert.AreEqual(new string[] { "a", "+", "bbbb" }, t);
        }

        [TestMethod]
        public void TestMethod3()
        {
            string[] t = ExpressionParser_Accessor.ExpressionStringToStringArray("aaaa+b").ToArray();
            CollectionAssert.AreEqual(new string[] { "aaaa", "+", "b" }, t);
        }

        [TestMethod]
        public void TestMethod5()
        {
            string[] t = ExpressionParser_Accessor.ExpressionStringToStringArray("aaaa+-sin25+cos33").ToArray();
            CollectionAssert.AreEqual(new string[] { "aaaa", "+", "-" , "sin", "25", "+", "cos", "33" }, t);
        }

        [TestMethod]
        public void TestMethod4()
        {
            string[] t = ExpressionParser_Accessor.ExpressionStringToStringArray("").ToArray();
            CollectionAssert.AreEqual(new string[0], t);
        }

        [TestMethod]
        public void TestMethod6()
        {
            string[] t = ExpressionParser_Accessor.ExpressionStringToStringArray("sin(20)").ToArray();
            CollectionAssert.AreEqual(new string[] { "sin", "(", "20", ")" }, t);
        }
    }

    [TestClass]
    public class sdf
    {
        [TestMethod]
        public void TestMethod1()
        {
            IToken[] t = new IToken[] { new ValueToken(10), new FunctionToken(Functions.Cos), new FunctionToken(Functions.Cos), new OperationToken(Operations.Add), new SymbolToken(Symbols.CloseBracket) };
            string[] s = new string[] {"10", "cos", "cosine", "+", ")"};
            CollectionAssert.AreEqual(t, ExpressionParser_Accessor.StringArrayToTokenArray(s).ToArray());
        }
    }

    [TestClass]
    public class adfadsf
    {
        [TestMethod]
        public void TestMethod1()
        {
            IToken[] t = new IToken[] { new ValueToken(10), new OperationToken(Operations.Add), new ValueToken(20) };
            IToken[] a = new IToken[] { new ValueToken(10), new ValueToken(20), new OperationToken(Operations.Add) };
            CollectionAssert.AreEqual(a, ExpressionParser_Accessor.TokenArrayRPN(t).ToArray());
        }
    }
}
