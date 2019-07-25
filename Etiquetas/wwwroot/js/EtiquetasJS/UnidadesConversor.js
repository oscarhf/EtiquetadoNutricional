function isMasa(unidad){
    if (unidad == "g" ||  unidad == "hg" || unidad == "dag" || unidad == "dg" ||unidad == "cg" ||unidad == "mg" || unidad == "ug" ){
        return true;
    }
    return false;
}

function isLiquid(unidad){
    if (unidad == "ml" ||  unidad == "l" ){
        return true;
    }
    return false;
}

function isCasera(unidad){
    if (unidad == "cdta" ||  unidad == "cda" || unidad == "t240" || unidad == "t200" || unidad == "v240" || unidad == "t200" || unidad == "t240" || unidad == "OzFl" || unidad == "taza" || unidad == "vaso" ){
        return true;
    }
    return false;
}

function isCaseraMasa(unidad){
    if (unidad == "Oz"  ){
        return true;
    }
    return false;
}

function isCaseraLiquid(unidad){
    if ( unidad == "cdta" ||  unidad == "cda" || unidad == "t240" || unidad == "t200" || unidad == "v240" || unidad == "t200" || unidad == "t240" || unidad == "taza" || unidad == "vaso" ){
        return true;
    }
    return false;
}


function isCaseraCucharita(unidad){
    if (  unidad == "cdta" ){
        return true;
    }
    return false;
}

function isCaseraCucharada(unidad){
    if (  unidad == "cda" ){
        return true;
    }
    return false;
}

function isCaseraTaza(unidad){
    if (  unidad == "t240" || unidad == "t200" || unidad == "taza"){
        return true;
    }
    return false;
}


function isCaseraVaso(unidad){
    if (  unidad == "v240" || unidad == "v200" || unidad == "vaso" ){
        return true;
    }
    return false;
}


function isCaseraOnzaFluida(unidad){
    if (  unidad == "OzFl" ){
        return true;
    }
    return false;
}

function conversor(cantidadOrigen, unidadOrigen, unidadDestino , densidad,unidadDensidad){
    
    if (unidadOrigen == "g"){
        if (unidadDestino == "hg"){
            return g2hg (cantidadOrigen);
        }else if (unidadDestino == "dag"){
            return g2dag (cantidadOrigen);
        }else if (unidadDestino == "g"){
            return g2g (cantidadOrigen);
        }else if (unidadDestino == "dg"){
            return g2dg (cantidadOrigen);
        }else if (unidadDestino == "cg"){
            return g2cg (cantidadOrigen);
        }else if (unidadDestino == "mg"){
            return g2mg (cantidadOrigen);
        }else if (unidadDestino == "ug"){
            return g2ug (cantidadOrigen);
        }
    
    }else if (unidadOrigen == "mg"){
        if (unidadDestino == "hg"){
            return mg2hg (cantidadOrigen);
        }else if (unidadDestino == "dag"){
            return mg2dag (cantidadOrigen);
        }else if (unidadDestino == "g"){
            return mg2g (cantidadOrigen);
        }else if (unidadDestino == "dg"){
            return mg2dg (cantidadOrigen);
        }else if (unidadDestino == "cg"){
            return mg2cg (cantidadOrigen);
        }else if (unidadDestino == "mg"){
            return mg2mg (cantidadOrigen);
        }else if (unidadDestino == "ug"){
            return mg2ug (cantidadOrigen);
        }
     }else if (unidadOrigen == "ug"){
        if (unidadDestino == "hg"){
            return ug2hg (cantidadOrigen);
        }else if (unidadDestino == "dag"){
            return ug2dag (cantidadOrigen);
        }else if (unidadDestino == "g"){
            return ug2g (cantidadOrigen);
        }else if (unidadDestino == "dg"){
            return ug2dg (cantidadOrigen);
        }else if (unidadDestino == "cg"){
            return ug2cg (cantidadOrigen);
        }else if (unidadDestino == "mg"){
            return ug2mg (cantidadOrigen);
        }else if (unidadDestino == "ug"){
            return ug2ug (cantidadOrigen);
        }
    }else if (unidadOrigen == "hg"){
        if (unidadDestino == "hg"){
            return hg2hg (cantidadOrigen);
        }else if (unidadDestino == "dag"){
            return hg2dag (cantidadOrigen);
        }else if (unidadDestino == "g"){
            return hg2g (cantidadOrigen);
        }else if (unidadDestino == "dg"){
            return hg2dg (cantidadOrigen);
        }else if (unidadDestino == "cg"){
            return hg2cg (cantidadOrigen);
        }else if (unidadDestino == "mg"){
            return hg2mg (cantidadOrigen);
        }else if (unidadDestino == "ug"){
            return hg2ug (cantidadOrigen);
        }
    }else if (unidadOrigen == "dag"){
        if (unidadDestino == "hg"){
            return dag2hg (cantidadOrigen);
        }else if (unidadDestino == "dag"){
            return dag2dag (cantidadOrigen);
        }else if (unidadDestino == "g"){
            return dag2g (cantidadOrigen);
        }else if (unidadDestino == "dg"){
            return dag2dg (cantidadOrigen);
        }else if (unidadDestino == "cg"){
            return dag2cg (cantidadOrigen);
        }else if (unidadDestino == "mg"){
            return dag2mg (cantidadOrigen);
        }else if (unidadDestino == "ug"){
            return dag2ug (cantidadOrigen);
        }
    }else if (unidadOrigen == "dg"){
        if (unidadDestino == "hg"){
            return dg2hg (cantidadOrigen);
        }else if (unidadDestino == "dag"){
            return dg2dag (cantidadOrigen);
        }else if (unidadDestino == "g"){
            return dg2g (cantidadOrigen);
        }else if (unidadDestino == "dg"){
            return dg2dg (cantidadOrigen);
        }else if (unidadDestino == "cg"){
            return dg2cg (cantidadOrigen);
        }else if (unidadDestino == "mg"){
            return dg2mg (cantidadOrigen);
        }else if (unidadDestino == "ug"){
            return dg2ug (cantidadOrigen);
        }
    }else if (unidadOrigen == "cg"){
        if (unidadDestino == "hg"){
            return cg2hg (cantidadOrigen);
        }else if (unidadDestino == "dag"){
            return cg2dag (cantidadOrigen);
        }else if (unidadDestino == "g"){
            return cg2g (cantidadOrigen);
        }else if (unidadDestino == "dg"){
            return cg2dg (cantidadOrigen);
        }else if (unidadDestino == "cg"){
            return cg2cg (cantidadOrigen);
        }else if (unidadDestino == "mg"){
            return cg2mg (cantidadOrigen);
        }else if (unidadDestino == "ug"){
            return cg2ug (cantidadOrigen);
        }
    }else if(unidadOrigen == "ml"){
        if (unidadDestino == "g" && unidadDensidad == "g/cm3"){
            if (typeof densidad === 'undefined' ){
                return ml2gXg_cm3 (cantidadOrigen,1);
            }else{
                return ml2gXg_cm3 (cantidadOrigen,densidad);
            }
        }
    } else if(unidadOrigen == "l"){
        if (unidadDestino == "ml" ){
          
            return l2ml (cantidadOrigen);
          
        }
    } else if(unidadOrigen == "cdta"){
        return cdta2ml(cantidadOrigen);}

    else if(unidadOrigen == "cda"){
        return cda2ml(cantidadOrigen);}

    else if(unidadOrigen == "t240"){
        return t2402ml(cantidadOrigen);}

    else if(unidadOrigen == "t200"){
        return t2002ml(cantidadOrigen);}

    else if(unidadOrigen == "v240"){
        return v2402ml(cantidadOrigen);}

    else if(unidadOrigen == "v200"){
        return v2002ml(cantidadOrigen);}

    else if(unidadOrigen == "OzFl"){
        return OzFl2ml(cantidadOrigen);}

    else if(unidadOrigen == "Oz"){
        return Oz2g(cantidadOrigen);}
    
}



function ml2gXg_cm3(cantidadOrigen,densidad){
    return cantidadOrigen * densidad;
}

function g2hg (cantidadOrigen){
    return cantidadOrigen / 10;
}
function g2dag (cantidadOrigen){
    return cantidadOrigen / 10;
}
function g2g (cantidadOrigen){
    return cantidadOrigen;
}
function g2dg (cantidadOrigen){
    return cantidadOrigen * 10;
}
function g2cg (cantidadOrigen){
    return cantidadOrigen * 100;
}
function g2mg (cantidadOrigen){
    return cantidadOrigen * 1000;
}
function g2ug (cantidadOrigen){
    return cantidadOrigen * 1000000;
}

function mg2hg  (cantidadOrigen){
    return cantidadOrigen / 100000;
}
function mg2dag (cantidadOrigen){
    return cantidadOrigen / 10000;
}
function mg2g  (cantidadOrigen){
    return cantidadOrigen / 1000;
}
function mg2dg (cantidadOrigen){
    return cantidadOrigen / 100;
}
function mg2cg (cantidadOrigen){
    return cantidadOrigen / 10;
}
function mg2mg (cantidadOrigen){
     return cantidadOrigen;
}
function mg2ug (cantidadOrigen){
    return cantidadOrigen * 1000;
}

function ug2hg  (cantidadOrigen){
    return cantidadOrigen / 100000000;
}
function ug2dag (cantidadOrigen){
    return cantidadOrigen / 10000000;
}
function ug2g  (cantidadOrigen){
    return cantidadOrigen / 1000000;
}
function ug2dg (cantidadOrigen){
    return cantidadOrigen / 100000;
}
function ug2cg (cantidadOrigen){
    return cantidadOrigen / 10000;
}
function ug2mg (cantidadOrigen){
    return cantidadOrigen / 1000;
}
function ug2ug (cantidadOrigen){
     return cantidadOrigen;
}

function hg2hg (cantidadOrigen){
     return cantidadOrigen;
}
function hg2dag (cantidadOrigen){
    return cantidadOrigen * 10;
}
function hg2g  (cantidadOrigen){
    return cantidadOrigen * 100;
}
function hg2dg (cantidadOrigen){
    return cantidadOrigen * 1000;
}
function hg2cg (cantidadOrigen){
    return cantidadOrigen * 10000;
}
function hg2mg (cantidadOrigen){
    return cantidadOrigen * 100000;
}
function hg2ug (cantidadOrigen){
    return cantidadOrigen * 100000000;
}

function dag2hg  (cantidadOrigen){
    return cantidadOrigen / 10;
}
function dag2dag (cantidadOrigen){
     return cantidadOrigen;
}
function dag2g  (cantidadOrigen){
    return cantidadOrigen * 10;
}
function dag2dg (cantidadOrigen){
    return cantidadOrigen * 100;
}
function dag2cg (cantidadOrigen){
    return cantidadOrigen * 1000;
}
function dag2mg (cantidadOrigen){
    return cantidadOrigen * 10000;
}
function dag2ug (cantidadOrigen){
    return cantidadOrigen * 10000000;
}

function dg2hg  (cantidadOrigen){
    return cantidadOrigen * 10;
}
function dg2dag (cantidadOrigen){
    return cantidadOrigen / 100;
}
function dg2g  (cantidadOrigen){
    return cantidadOrigen / 10;
}
function dg2dg (cantidadOrigen){
     return cantidadOrigen;
}
function dg2cg (cantidadOrigen){
    return cantidadOrigen * 10;
}
function dg2mg  (cantidadOrigen){
    return cantidadOrigen * 100;
}
function dg2ug (cantidadOrigen){
    return cantidadOrigen * 100000;
}

function cg2hg  (cantidadOrigen){
    return cantidadOrigen / 10000;
}
function cg2dag (cantidadOrigen){
    return cantidadOrigen / 1000;
}
function cg2g  (cantidadOrigen){
    return cantidadOrigen / 100;
}
function cg2dg (cantidadOrigen){
    return cantidadOrigen / 10;
}
function cg2cg (cantidadOrigen){
     return cantidadOrigen;
}
function cg2mg (cantidadOrigen){
    return cantidadOrigen * 10;
}
function cg2ug (cantidadOrigen){
    return cantidadOrigen * 10000;
}


function l2ml(cantidadOrigen){
    return cantidadOrigen * 1000;
}



function cdta2ml(cantidadOrigen){
    return cantidadOrigen * 5;
}
function cda2ml(cantidadOrigen){
return cantidadOrigen * 15;}
function t2402ml(cantidadOrigen){
return cantidadOrigen * 240;}
function t2002ml(cantidadOrigen){
return cantidadOrigen * 200;}
function v2402ml(cantidadOrigen){
return cantidadOrigen * 240;}
function v2002ml(cantidadOrigen){
return cantidadOrigen * 200;}
function OzFl2ml(cantidadOrigen){
return cantidadOrigen * 30;}
function Oz2g(cantidadOrigen){
return cantidadOrigen * 28;
}




