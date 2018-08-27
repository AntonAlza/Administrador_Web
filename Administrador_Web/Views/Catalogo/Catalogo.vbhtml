@Code
    ViewData("Title") = "Catalogo"
End Code

<h2>Catalogo</h2>
<body>
    <input type="text" name="as" value="" />
    @Using Html.BeginForm("Catalogo", "Catalogo", Nothing, FormMethod.Post, New With {.enctype = "multipart/form-data"})
        @Html.Raw(ViewBag.Error)

        @<div>
            <span>Excel File </span> <input type="file" name="excelfile" />
            <br />
            <input type="submit" value="Import" />
            
        </div>
    End Using


    <h3>Lista Productos</h3>

    <table cellpadding="2" cellspacing="2" border="1">
        <tr>
            <th>ISIN</th>
            <th>Cupon</th>
            <th>Vencimiento</th>
            <th>Pago</th>
            <th>Fijación</th>
            <th>Tasa Bono</th>
            <th>Interes Bono</th>
            <th>Amortización Bono</th>
            <th>Flujo Bono</th>
            <th>Flag Cupon</th>
        </tr>
        @code
            For Each p In ViewBag.Lista
                @<tr>
                    <td>@p.CodIsin</td>
                    <td>@p.NroCupon</td>
                    <td>@p.FecVcto</td>
                    <td>@p.FecPago</td>
                    <td>@p.FecFijacion</td>
                    <td>@p.NumTasaBono</td>
                    <td>@p.MtoInteresBono</td>
                    <td>@p.MtoAmortBono</td>
                    <td>@p.MtoFlujoBono</td>
                    <td>@p.FlgCupon</td>

                </tr>
            Next
        End Code

    </table>
</body>

