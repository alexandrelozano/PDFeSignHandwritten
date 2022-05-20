# PDFeSignHandwritten
Windows executable for sign a PDF with a certificate and a handwritten firm.

Winforms csharp .NET 4.7.2

Uses the [GhostScript](https://www.ghostscript.com/) interpreter portable edition to render. I put it embedded into the zip.

Uses the [iText 7](https://itextpdf.com/es/products/itext-7/itext-7-community) library to create the digital signature.

Download windows portable version [PDFeSignHandwritten v1.5.3](https://github.com/alexandrelozano/PDFeSignHandwritten/releases/download/v1.5.3/PDFeSignHandwritten_v1.5.3.zip)

![Sample](https://raw.githubusercontent.com/alexandrelozano/PDFeSignHandwritten/main/PDFeSignHandwritten/samples/PDFeSignHandwritten.gif)

### Command line parameters

| Parameter  | Value | Description |
| ---   | ---         | ---     |
| p | [path] | PDF file to open |
| n | [name] | Sign name info |
| c | [contactinfo] |	Sign contact info |
| l | [location] | Sign location info |
| r | [reason] | Sign reason info |
| f | [certificate] |	Certificate path |
| p | [password] | Certificate password |
| t | [URL] | Timestamp server URL |
| o | [path] | Signed PDF output path |
| i | [path] | Image to use for sign |
| a | | Open PDF after sign |
| h | | Show help |

## Changelog
### v1.5.4
- New button in main screen to fill PDF fields
### v1.5.3
- New option to open PDF after sign
- New command line option to set the image to use for sign
### v1.5.2
- Can choose pen color
- Can choose pen width
- Drawing signature enhancement
- Load signature picture from file
### v1.5.1
- Transparent signature image
- Signature text improvements
### v1.5 
- Application accepts command line parameters
### v1.4 
- Uses iText 7 to create the digital signature
### v1.3 
- Uses PDFSharp to create the digital signature
### v1.2 
- Uses GhostScript to render the PDF
### v1.0 
- Uses Free Spire.PDF to render and create the digital signature
