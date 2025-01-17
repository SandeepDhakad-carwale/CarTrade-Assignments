import React,{useEffect} from 'react'
import '../styleSheets/layout.css'
import Filter from './Filter'
import Hero from './Hero'
import Header from './Header'
import Loader from './Loader.jsx'


import { useSelector,useDispatch } from "react-redux";
import { fetchFilteredCars } from '../redux/actions/carDataActions.js'


const Layout = () => {
  console.log("layout re-renders.....")

  const dispatch = useDispatch();
  const { fuel, budget, loading,sortBy } = useSelector((state) => state.carData);

    
  useEffect(() => {
    console.log("start fetching cars according to filters")
    dispatch(fetchFilteredCars());
    console.log("fetching successfull")
  }, [fuel, budget, sortBy,dispatch]);

  return (
   <>
   {loading && <Loader/>}
    <Header/>
   <div className="layout">
   <Filter/>
   <Hero/>
   </div>
   </>
  )
}

export default Layout