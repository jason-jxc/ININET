using System;
using System.IO;
using ININET.Model;
using ININET.Model.Formatting;

namespace ININET
{
    /// <summary>
    ///     Represents an INI data parser for streams.
    /// </summary>
    public class ININETStreamParser
    {
        /// <summary>
        ///     This instance will handle ini data parsing and writing
        /// </summary>
        public ININETStringParser Parser { get; protected set; }

        /// <summary>
        ///     Ctor
        /// </summary>
        public ININETStreamParser() : this (new ININETStringParser()) {}

        /// <summary>
        ///     Ctor
        /// </summary>
        /// <param name="parser"></param>
        public ININETStreamParser(ININETStringParser parser)
        {
            Parser = parser;
        }
        #region Public Methods

        /// <summary>
        ///     Reads data in INI format from a stream.
        /// </summary>
        /// <param name="reader">Reader stream.</param>
        /// <returns>
        ///     And <see cref="ININETData"/> instance with the readed ini data parsed.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///     Thrown if <paramref name="reader"/> is <c>null</c>.
        /// </exception>
        public ININETData ReadData(StreamReader reader)
        {
            if (reader == null)
                throw new ArgumentNullException("reader");
            
            return Parser.Parse(reader.ReadToEnd());
        }

        /// <summary>
        ///     Writes the ini data to a stream.
        /// </summary>
        /// <param name="writer">A write stream where the ini data will be stored</param>
        /// <param name="iniData">An <see cref="ININETData"/> instance.</param>
        /// <exception cref="ArgumentNullException">
        ///     Thrown if <paramref name="writer"/> is <c>null</c>.
        /// </exception>
        public void WriteData(StreamWriter writer, ININETData iniData)
        {
            if (iniData == null)
                throw new ArgumentNullException("iniData");
            if (writer == null)
                throw new ArgumentNullException("writer");

            writer.Write(iniData.ToString());
        }

        
        /// <summary>
        ///     Writes the ini data to a stream.
        /// </summary>
        /// <param name="writer">A write stream where the ini data will be stored</param>
        /// <param name="iniData">An <see cref="ININETData"/> instance.</param>
        /// <param name="formatter">Formaterr instance that controls how the ini data is transformed to a string</param>
        /// <exception cref="ArgumentNullException">
        ///     Thrown if <paramref name="writer"/> is <c>null</c>.
        /// </exception>
        public void WriteData(StreamWriter writer, ININETData iniData, IIniDataFormatter formatter)
        {
            if (formatter == null)
                throw new ArgumentNullException("formatter");
            if (iniData == null)
                throw new ArgumentNullException("iniData");
            if (writer == null)
                throw new ArgumentNullException("writer");

            writer.Write(iniData.ToString(formatter));
        }

        #endregion
    }
}
