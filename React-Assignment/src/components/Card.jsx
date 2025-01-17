import React, { useState } from 'react'
import '../styleSheets/Card.css'



const Card = ({carDetail}) => {
   //  console.log("card component re-renders...")
   // console.log("carddetauls",carDetail)
   // console.log("imageUrl:",typeof carDetail.imageUrl)
   // console.log("makeYear:",typeof carDetail.makeYear)
   // console.log("carname:",typeof carDetail.carName)
   // console.log("km:",typeof carDetail.km)
   // console.log("fuel:",typeof carDetail.fuel)
   // console.log("cityName:",typeof carDetail.cityName)
   // console.log("price:",typeof carDetail.price)

    

  return (
    <div className='card'>
       <div className="imgContainer">
  <img
    src={carDetail.imageUrl}
    alt="Car Image"
    onError={(e) => {
      e.target.onerror = null; 
      e.target.src = "/image_not_found.png"; 
    }}
  />
</div>
       <div className="discription">
        <div className="details">
            <h3 className='carName'>{`${carDetail.makeYear} ${carDetail.carName}`} </h3>
            <p className='carStates'>{`${carDetail.km} km | ${carDetail.fuel} | ${carDetail.cityName}`}</p>
        </div>
        <div className="price">{`Rs ${carDetail.price}`}</div>
        <div className="offer">Make Offer</div>
        <div className="getdetailsbtn">Get Seller Details</div>
       </div>
    </div>
  )
}

export default Card