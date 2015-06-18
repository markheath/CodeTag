using System;
using System.Linq;
using System.Windows.Forms;
using WindowsLive.Writer.Api;

namespace SoundCode.CodeTag
{
    // a helpful tutorial: http://www.codemag.com/article/0804092

    [WriterPlugin("301e5d4a-dbe9-4ade-aeb7-c76b29e69214", 
                    "Wrap in <code>",
                Description = "Wrap a block of code",
                HasEditableOptions = false,
                PublisherUrl = "http://markheath.net")]
    [InsertableContentSource("Code")]
    public class CodePlugin : ContentSource
    {
        public override DialogResult CreateContent(IWin32Window dialogOwner, ref string content)
        {
            if (!String.IsNullOrEmpty(content))
            {
                var leadingWhiteSpace = new string(content.TakeWhile(Char.IsWhiteSpace).ToArray());
                var trailingWhiteSpace = new string(content.Reverse().TakeWhile(Char.IsWhiteSpace).Reverse().ToArray());
                var trimmed = content.Substring(leadingWhiteSpace.Length, content.Length - leadingWhiteSpace.Length - trailingWhiteSpace.Length);

                content = leadingWhiteSpace + "<code>" + trimmed + "</code>" + trailingWhiteSpace;
            }
            return DialogResult.OK;
        }

        
    }
}
