﻿using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.IO;

namespace whisper_language
{
    class Program
    {
        static void Main(string[] args)
        {
            try {
                       var a = CharStreams.fromPath("../test.pg");
                       var lexer = new TLLexer(a);
                       TLParser parser = new TLParser(new CommonTokenStream(lexer));
                       parser.BuildParseTree=true;
                       var tree = parser.parse();
                       Scope scope = new Scope(null,false);
                       var visitor = new EvalVisitor(scope,new Dictionary<string, Function>(), new Dictionary<string, BuildInFunction>());
                visitor.Visit(tree);
            } catch (Exception e) {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace.ToString());
                   }
        }
    }
}