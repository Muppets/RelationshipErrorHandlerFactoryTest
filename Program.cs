using DocumentFormat.OpenXml.Packaging;
using System;

namespace RelationshipErrorHandlerFactoryTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var doc = WordprocessingDocument.Open("BrokenURI.docx", isEditable: true, new OpenSettings
            {
                RelationshipErrorHandlerFactory = _ => new RemoveMalformedHyperlinksRelationshipErrorHandler(),
            });
        }

        private sealed class RemoveMalformedHyperlinksRelationshipErrorHandler : RelationshipErrorHandler
        {
            // Works
            //public override string Rewrite(Uri partUri, string id, string uri) => $"https://error{new string('r', uri.Length)}";

            // Fails with "Data at the root level is invalid"
            public override string Rewrite(Uri partUri, string id, string uri) => $"https://error";
        }
    }
}
