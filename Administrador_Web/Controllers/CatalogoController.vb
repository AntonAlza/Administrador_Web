Imports System.Web.Mvc
Imports Microsoft.Office.Interop
Imports System.IO

Namespace Controllers
    Public Class CatalogoController
        Inherits Controller
        Dim Lista As List(Of Bono_Flujo) = New List(Of Bono_Flujo)
        ' GET: Catalogo
        Function Catalogo() As ActionResult
            ViewBag.Lista = Lista
            Return View()
        End Function


        <HttpPost()>
        Function Catalogo(ByVal excelfile As HttpPostedFileBase) As ActionResult

            If (excelfile Is Nothing Or excelfile.ContentLength = 0) Then
                ViewBag.Error = "Por favor ingrese Excel<br>"
                Return View("Catalogo")
            Else
                If (excelfile.FileName.EndsWith("xls") Or excelfile.FileName.EndsWith("xlsx")) Then
                    Dim path As String = Server.MapPath("~/Content/" + excelfile.FileName)
                    If (System.IO.File.Exists(path)) Then
                        System.IO.File.Delete(path)
                    End If
                    excelfile.SaveAs(path)
                    Dim application As Excel.Application = New Excel.Application
                    Dim WorkBook As Excel.Workbook = application.Workbooks.Open(path)
                    Dim WorkSheet As Excel.Worksheet = WorkBook.ActiveSheet
                    Dim Range As Excel.Range = WorkSheet.UsedRange
                    Dim i As Integer



                    For i = 5 To Range.Rows.Count
                        Dim p As Bono_Flujo = New Bono_Flujo
                        p.CodIsin = Range.Cells(i, 1).Value
                        p.NroCupon = Range.Cells(i, 2).Value
                        p.FecVcto = Range.Cells(i, 3).Value
                        p.FecPago = Range.Cells(i, 4).Value
                        p.FecFijacion = Range.Cells(i, 5).Value
                        p.NumTasaBono = Range.Cells(i, 6).Value
                        p.MtoInteresBono = Range.Cells(i, 7).Value
                        p.MtoAmortBono = Range.Cells(i, 8).Value
                        p.MtoFlujoBono = Range.Cells(i, 9).Value
                        p.FlgCupon = Range.Cells(i, 10).Value


                        Lista.Add(p)
                    Next
                    ViewBag.Lista = Lista
                    Return View("Catalogo")
                    WorkBook.Close(path)

                Else
                    ViewBag.Lista = Lista
                    ViewBag.Error = "Archivo Incorrecto <br>"
                    Return View("Catalogo")
                End If
            End If

        End Function


    End Class
End Namespace