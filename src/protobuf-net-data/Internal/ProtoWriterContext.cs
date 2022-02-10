// Copyright (c) Richard Dingwall, Arjen Post. See LICENSE in the project root for license information.

using System.Collections.Generic;

namespace ProtoBuf.Data.Internal
{
    internal class ProtoWriterContext
    {
        private readonly Stack<SubItemToken> subItemTokens = new Stack<SubItemToken>();

        public ProtoWriterContext(ProtoWriter writer, ProtoDataWriterOptions options)
        {
            this.Writer = writer;
            this.Options = options;
        }

        public ProtoWriter Writer { get; }

        public ProtoDataWriterOptions Options { get; }

        public IList<ProtoDataColumn> Columns { get; set; } = new List<ProtoDataColumn>();

        public void StartSubItem(object instance)
        {
#pragma warning disable 612, 618
            this.subItemTokens.Push(ProtoWriter.StartSubItem(instance, this.Writer));
#pragma warning restore 612, 618
        }

        public void EndSubItem()
        {
#pragma warning disable 612, 618
            ProtoWriter.EndSubItem(this.subItemTokens.Pop(), this.Writer);
#pragma warning restore 612, 618
        }
    }
}
