function showNotification(from, align,type,text){

  $.notify({
      icon: "info_outline",
      message: text

  },{
      type: type,
      timer: 4000,
      placement: {
          from: from,
          align: align
      }
  });
}