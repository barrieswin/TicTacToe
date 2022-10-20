window.ShowWinner = (player) => {
    Swal.fire({
        title: player + ' wins!!',
        width: 400,
        padding: '4em',
        color: '#b47875',
    })
}
window.ShowTie = () => {
    Swal.fire({
        title: 'Tie!',
        width: 400,
        padding: '4em',
        color: '#b47875',
    })
}