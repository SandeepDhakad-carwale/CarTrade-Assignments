import React from 'react'
import '../styleSheets/Hero.css'
import Card from './Card'
import { useSelector } from 'react-redux'
import Sort from './Sort'

const Hero = () => {
    console.log("hero re-renders...")

    const {filteredCars}=useSelector((state) => state.carData);

    console.log("filteredCArs in hero comp",filteredCars)
  return (
    <div className='heroContainer'>
      <Sort/>
      {filteredCars && filteredCars.length > 0
    ? filteredCars.map((carDetail,ind) => (
        <Card key={carDetail.profileId.toString()+ind} carDetail={carDetail} />
      ))
    : ""}
        
    </div>
  )
}

export default Hero