using SolidWorks.Interop.sldworks;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace sw_part_auto_test
{
    public class SWDocSpecification
    {
        private static readonly NLog.Logger logger =
            NLog.LogManager.GetCurrentClassLogger();
        public static DocumentSpecification GetDocumentSpecification(
            ISldWorks swApp, string path)
        {
                logger.Debug("\n Getting Document Specification for File: " +
                     path);
            try
            {
                try
                {
                    if (path == null ||
                        string.Compare(path, "") == 0 ||
                        swApp == null)
                        throw new ArgumentException();
                }
                catch (ArgumentException exception)
                {
                    logger.Error(exception, "\n ERROR: Document Specification path or SolidWorks app reference was null or empty");

                    return null;
                }

                try
                {
                    logger.Debug("\n Checking file " + path + " exists");

                    if (!File.Exists(path))
                        throw new ArgumentException();

                    logger.Debug("\n File " + path + " Found");
                }
                catch (ArgumentException exception)
                {
                    logger.Error(exception, "\n ERROR: File " + path + " Not Found");

                    return null;
                }

                DocumentSpecification documentSpecification =
                    (DocumentSpecification)swApp.GetOpenDocSpec(path);

                logger.Debug("\n Returning Document Specification for " + path +
                    "\n " + documentSpecification);

                if (documentSpecification == null)
                    throw new Exception();

                return documentSpecification;
            } catch (Exception exception)
            {
                logger.Error(exception, "\n ERROR: Could Not Get Document Specification For " +
                    path);

                return null;
            }
        }
    }
}
