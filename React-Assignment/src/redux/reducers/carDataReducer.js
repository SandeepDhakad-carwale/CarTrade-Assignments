const initialState = {
    fuel: [],
    budget: { start: 8, end: 16 },   // bydefault 8-16 rakh rhe h 
    filteredCars: [], 
    loading: false,
  };
  
  const carReducer = (state = initialState, action) => {
    switch (action.type) {
      case "SET_FUEL":
        return { ...state, fuel: action.payload };   
  
      case "SET_BUDGET":
        return { ...state, budget: action.payload }; 
     
        case "SET_CARS":
          return {...state,filteredCars:action.payload};
          
      case "FETCH_CARS_REQUEST":
        return { ...state, loading: true };
  
      case "FETCH_CARS_SUCCESS":
        return { ...state, loading: false, filteredCars: action.payload }; // we have to give array of carDetails as a payload
  
  
      default:
        return state;
    }
  };

  export default carReducer;