using System;

public static class Functions
{
    // Funcion copiada de: https://gist.github.com/gregorypilar/1569baf02f011ff25f27697638435aad
    // Arregla por mi (Ezequiel Perez)
    public static bool ValidaCedula(string cedula)
    {
        int verificador = 0;
        int digito = 0;
        int digitoVerificador = 0;
        int digitoImpar = 0;
        int sumaPar = 0;
        int sumaImpar = 0;
        int longitud = 0;

        try {
            longitud = Convert.ToInt32(cedula.Length);

            if (longitud == 11) {
                digitoVerificador = Convert.ToInt32(cedula.Substring(10, 1));

                for (int i = 9; i >= 0; i--) {
                    digito = Convert.ToInt32(cedula.Substring(i, 1));
                    if ((i % 2) != 0) {
                        digitoImpar = digito * 2;
                        if (digitoImpar >= 10) digitoImpar = digitoImpar - 9;
                        sumaImpar = sumaImpar + digitoImpar;
                    }
                    else sumaPar = sumaPar + digito;
                }

                verificador = 10 - ((sumaPar + sumaImpar) % 10);

                if (((verificador == 10) && (digitoVerificador == 0)) ||
                    (verificador == digitoVerificador))
                    return true;
            }
            else {}
        }
        catch {}

        return false;
    }

    // tampoco es mio
    public static string toText(this long value)
    {
        string Num2Text = "";

        if (value == 0) Num2Text = "CERO";
        else if (value == 1) Num2Text = "UNO";
        else if (value == 2) Num2Text = "DOS";
        else if (value == 3) Num2Text = "TRES";
        else if (value == 4) Num2Text = "CUATRO";
        else if (value == 5) Num2Text = "CINCO";
        else if (value == 6) Num2Text = "SEIS";
        else if (value == 7) Num2Text = "SIETE";
        else if (value == 8) Num2Text = "OCHO";
        else if (value == 9) Num2Text = "NUEVE";
        else if (value == 10) Num2Text = "DIEZ";
        else if (value == 11) Num2Text = "ONCE";
        else if (value == 12) Num2Text = "DOCE";
        else if (value == 13) Num2Text = "TRECE";
        else if (value == 14) Num2Text = "CATORCE";
        else if (value == 15) Num2Text = "QUINCE";
        else if (value < 20) Num2Text = "DIECI" + toText(value - 10);
        else if (value == 20) Num2Text = "VEINTE";
        else if (value < 30) Num2Text = "VEINTI" + toText(value - 20);
        else if (value == 30) Num2Text = "TREINTA";
        else if (value == 40) Num2Text = "CUARENTA";
        else if (value == 50) Num2Text = "CINCUENTA";
        else if (value == 60) Num2Text = "SESENTA";
        else if (value == 70) Num2Text = "SETENTA";
        else if (value == 80) Num2Text = "OCHENTA";
        else if (value == 90) Num2Text = "NOVENTA";
        else if (value < 100) Num2Text = toText((value / 10) * 10) + " Y " + toText(value % 10);
        else if (value == 100) Num2Text = "CIEN";
        else if (value < 200) Num2Text = "CIENTO " + toText(value - 100);
        else if ((value == 200) || (value == 300) || (value == 400) || (value == 600) || (value == 800)) Num2Text = toText((value / 100)) + "CIENTOS";
        else if (value == 500) Num2Text = "QUINIENTOS";
        else if (value == 700) Num2Text = "SETECIENTOS";
        else if (value == 900) Num2Text = "NOVECIENTOS";
        else if (value < 1000) Num2Text = toText((value / 100) * 100) + " " + toText(value % 100);
        else if (value == 1000) Num2Text = "MIL";
        else if (value < 2000) Num2Text = "MIL " + toText(value % 1000);
        else if (value < 1000000)
        {
            Num2Text = toText((value / 1000)) + " MIL";
            if ((value % 1000) > 0) Num2Text = Num2Text + " " + toText(value % 1000);
        }

        else if (value == 1000000) Num2Text = "UN MILLON";
        else if (value < 2000000) Num2Text = "UN MILLON " + toText(value % 1000000);
        else if (value < 1000000000000)
        {
            Num2Text = toText((value / 1000000)) + " MILLONES ";
            if ((value - (value / 1000000) * 1000000) > 0) Num2Text = Num2Text + " " + toText(value - (value / 1000000) * 1000000);
        }

        else if (value == 1000000000000) Num2Text = "UN BILLON";
        else if (value < 2000000000000) Num2Text = "UN BILLON " + toText(value - (value / 1000000000000) * 1000000000000);

        else
        {
            Num2Text = toText((value / 1000000000000)) + " BILLONES";
            if ((value - (value / 1000000000000) * 1000000000000) > 0) Num2Text = Num2Text + " " + toText(value - (value / 1000000000000) * 1000000000000);
        }
        return Num2Text;

    }

    public static string toZodiacSign(this DateTime dt)
    {
        int mes = dt.Month;
        int dia = dt.Day;
        string sign = "";

        if ((dia>=21&&mes==1)||(dia<=19&&mes==2))    sign = "Acuario";
        if ((dia>=20&&mes==2)||(dia<=20&&mes==3))    sign = "Piscis";
        if ((dia>=21&&mes==3)||(dia<=20&&mes==4))    sign = "Aries";
        if ((dia>=21&&mes==4)||(dia<=21&&mes==5))    sign = "Tauro";
        if ((dia>=22&&mes==5)||(dia<=21&&mes==6))    sign = "Geminis";
        if ((dia>=21&&mes==6)||(dia<=23&&mes==7))    sign = "Cancer";
        if ((dia>=24&&mes==7)||(dia<=23&&mes==8))    sign = "Leo";
        if ((dia>=24&&mes==9)||(dia<=23&&mes==10))   sign = "Libra";
        if ((dia>=24&&mes==8)||(dia<=23&&mes==9))    sign = "Virgo";
        if ((dia>=24&&mes==10)||(dia<=22&&mes==11))  sign = "Escorpio";
        if ((dia>=23&&mes==11)||(dia<=21&&mes==12))  sign = "Sagitario";
        if ((dia>=22&&mes==12)||(dia<=20&&mes==1))   sign = "Capricornio";

        return sign;
    }
}
