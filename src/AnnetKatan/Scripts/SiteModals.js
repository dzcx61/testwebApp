$('#imageModal').on('show.bs.modal', function (event) {
  // Link that triggered the modal
  var link = $(event.relatedTarget) 
  // Extract info from data-* attributes
  var imageUrl = link.data('image-url')

  // Update the modal's content. We'll use jQuery here, but you could use a data binding library or other methods instead.
  var modal = $(this)
  modal.find('.modal-content img').attr('src', imageUrl)
})