import React from 'react';

function WithDataLoading(Component) {
  return function WithLoadingComponent({ isLoading, ...props }) {
    if (!isLoading) return <Component {...props} />;
    return (
      <p style={{ textAlign: 'center', fontSize: '30px' }}>
        Fetching data... (the API is slow or unavailable?)
      </p>
    );
  };
}
export default WithDataLoading;