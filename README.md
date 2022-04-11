# PDFeSignHandwritten
Windows executable for sign a PDF with a certificate and a handwritten firm.

Winforms csharp .NET 4.7.2

Uses the [GhostScript](https://www.ghostscript.com/) interpreter portable edition to render. I put it embedded into the zip.

Uses the [iText 7](https://itextpdf.com/es/products/itext-7/itext-7-community) library to create the digital signature.

Download windows portable version [PDFeSignHandwritten v1.4](https://raw.githubusercontent.com/alexandrelozano/PDFeSignHandwritten/main/Executables/PDFeSignHandwritten_v1.4.zip)

![Sample](https://raw.githubusercontent.com/alexandrelozano/PDFeSignHandwritten/main/PDFeSignHandwritten/samples/PDFeSignHandwritten.gif)

## Changelog

### V1.4 
Uses iText 7 to create the digital signature
### V1.3 
Uses PDFSharp to create the digital signature
### V1.2 
Uses GhostScript to render the PDF
### V1.0 
Uses Free Spire.PDF to render and create the digital signature
