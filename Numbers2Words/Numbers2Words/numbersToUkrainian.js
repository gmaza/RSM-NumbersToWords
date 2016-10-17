var result;
var money;
var price;
var rub, kop;
var ru, ko;
var litera = sotny = desatky = edinicy = "";
var k = 0, i, j, minus = "";

N = ["", "одна", "дві", "три", "чотири", "п'ять", "шість", "сім", "вісім", "дев'ять",
"", "одинадцять", "дванадцять", "тринадцять", "чотирнадцять", "п'ятнадцять", "шістнадцять", "сімнадцять", "вісімнадцять", "дев'ятнадцять",
"", "десять", "двадцять", "тридцять", "сорок", "пятдесят", "шістдесят", "сімдесят", "вісімдесят", "дев'яносто",
"", "сто", "двісті", "триста", "чотириста", "п'ятсот", "шістсот", "сімсот", "вісімсот", "дев'ятсот",
"тисяч", "тисяча", "тисячі", "тисячі", "тисячі", "тисяч", "тисяч", "тисяч", "тисяч", "тисяч",
"мільйонів", "мільйон", "мільйони", "мільйони", "мільйони", "мільйонів", "мільйонів", "мільйонів", "мільйонів", "мільйонів",
"мільярдів", "мільярд", "мільярди", "мільярди", "мільярди", "мільярдів", "мільярдів", "мільярдів", "мільярдів", "мільярдів"];

var M = new Array(10);
for (j = 0; j < 10; ++j)
    M[j] = new Array(N.length);

for (i = 0; i < N.length; i++)
    for (j = 0; j < 10; j++) {
        M[j][i] = N[k++]

    }

var R = new Array("гривень", "гривня", "гривні", "гривні", "гривні", "гривень", "гривень", "гривень", "гривень", "гривень");
var K = new Array("копійок", "копійка", "копійки", "копійки", "копійки", "копійок", "копійок", "копійок", "копійок", "копійок");

function num2str(money) {
    rub = "", kop = "";
    money = money.replace(",", ".");

    if (isNaN(money)) { document.getElementById(target).innerHTML = "Не числове значення"; return }
    if (money.substr(0, 1) == "-") { money = money.substr(1); minus = "мінус " }
    else minus = "";
    money = Math.round(money * 100) / 100 + "";
    if (money.indexOf(".") != -1) {
        rub = money.substr(0, money.indexOf("."));
        kop = money.substr(money.indexOf(".") + 1);
        if (kop.length == 1) kop += "0";
    }
    else rub = money;


    if (rub.length > 12) { document.getElementById(target).innerHTML = "завелике число"; return }

    ru = propis(price = rub, R);
    ko = propis(price = kop, K);
    ko != "" ? res = ru + " " + ko : res = ru;
    ru == "Нуль " + R[0] && ko != "" ? res = ko : 0;
    kop == 0 ? res += " нуль " + K[0] : 0; // добавляет "нуль копійок"
    result = ((minus + res).substr(0, 1).toUpperCase() + (minus + res).substr(1))
}

function propis(price, D) {
    litera = "";
    for (i = 0; i < price.length; i += 3) {
        sotny = desatky = edinicy = "";
        if (n(i + 2, 2) > 10 && n(i + 2, 2) < 20) {
            edinicy = " " + M[n(i + 1, 1)][1] + " " + M[0][i / 3 + 3];
            i == 0 ? edinicy += D[0] : 0;
        }
        else {
            edinicy = M[n(i + 1, 1)][0];
            edinicy == "одна" && (i >= 6) ? edinicy = "один" : 0;
            edinicy == "дві" && (i >= 6) ? edinicy = "два" : 0;
            i == 0 && edinicy != "" ? 0 : edinicy += " " + M[n(i + 1, 1)][i / 3 + 3];
            edinicy == " " ? edinicy = "" : (edinicy == " " + M[n(i + 1, 1)][i / 3 + 3]) ? 0 : edinicy = " " + edinicy;
            i == 0 ? edinicy += " " + D[n(i + 1, 1)] : 0;
            (desatky = M[n(i + 2, 1)][2]) != "" ? desatky = " " + desatky : 0;
        }
        (sotny = M[n(i + 3, 1)][3]) != "" ? sotny = " " + sotny : 0;
        if (price.substr(price.length - i - 3, 3) == "000" && edinicy == " " + M[0][i / 3 + 3]) edinicy = "";
        litera = sotny + desatky + edinicy + litera;
    }

    if (litera == " " + R[0]) return "Нуль" + litera;
    else return litera.substr(1);

}

function n(start, len) {
    if (start > price.length) return 0;
    else return Number(price.substr(price.length - start, len));
}


num2str(nnn);