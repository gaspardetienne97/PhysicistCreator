import React, {Component} from 'react';
import PropTypes from 'prop-types';
import {withStyles} from '@material-ui/core/styles';
import Button from '@material-ui/core/Button';
import {Link} from 'react-router-dom'
import Typography from '@material-ui/core/Typography'


const styles = theme => ({
    homeGrid: {
        display: 'grid',
        gridTemplateColumns: '25% 25% 25% 25%',
        gridTemplateRows: '30% 30% 30%',
        gridGap: `${theme.spacing.unit * 3}px`,
        backgroundColor: theme.palette.secondary.main,
        height: '100%',
        width: '100%'
    },
    logo: {
        border: '' + theme.palette.primary.dark + ' solid 1%',
        gridArea: '2 / 2 / span 1 / span 1',
        backgroundColor: theme.palette.primary.light,
    },
    description: {
        gridArea: '2 / 3 / span 1 / span 1',
        margin: theme.spacing.unit,

    },
    button: {
        position: 'relative',
        top: '40%',
        left: '50%'
    }
});


class Home extends Component {

    render() {
        const {classes} = this.props;
        return (
            <div className={classes.homeGrid}>
                <div className={classes.logo}>
                    logo goes here!
                </div>
                <div className={classes.description}>
                    <Typography variant="body1">
                        Lorem ipsum dolor sit amet, consectetur adipisicing elit. Assumenda distinctio
                        doloremque ducimus esse hic, illo incidunt neque perspiciatis quod repellat, repudiandae
                        rerum sit vitae. Aut incidunt inventore iste molestiae voluptatum?
                    </Typography>
                    <Link to='/gallery'>
                        <Button variant="contained" color="primary" className={classes.button}>
                            Get Started!
                        </Button>
                    </Link>
                </div>
            </div>
        );
    }
}


Home.propTypes = {
    classes: PropTypes.object.isRequired,
};

export default withStyles(styles)(Home);