import carReducer from "../redux/reducers/carDataReducer";

describe('carReducer', () => {
  const initialState = {
    fuel: [],
    budget: { start: 0, end: 99 },
    filteredCars: [],
    loading: false,
  };

  it('SET_FUEL action', () => {
    const action = { type: 'SET_FUEL', payload: ['Petrol'] };
    const expectedState = { ...initialState, fuel: ['Petrol'] };
    expect(carReducer(initialState, action)).toEqual(expectedState);
  });

  it('SET_BUDGET action', () => {
    const action = { type: 'SET_BUDGET', payload: { start: 10, end: 20 } };
    const expectedState = { ...initialState, budget: { start: 10, end: 20 } };
    expect(carReducer(initialState, action)).toEqual(expectedState);
  });

  it('FETCH_CARS_REQUEST action', () => {
    const action = { type: 'FETCH_CARS_REQUEST' };
    const expectedState = { ...initialState, loading: true };
    expect(carReducer(initialState, action)).toEqual(expectedState);
  });

  it('FETCH_CARS_SUCCESS action', () => {
    const action = { type: 'FETCH_CARS_SUCCESS', payload: [{ id: 1, name: 'Car 1' }] };
    const expectedState = { ...initialState, loading: false, filteredCars: [{ id: 1, name: 'Car 1' }] };
    expect(carReducer(initialState, action)).toEqual(expectedState);
  });
});
